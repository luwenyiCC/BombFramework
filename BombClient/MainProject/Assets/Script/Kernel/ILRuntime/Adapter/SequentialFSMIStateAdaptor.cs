
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using System.Collections.Generic;

public class SequentialFSMIStateAdaptor : CrossBindingAdaptor
{

    public override Type BaseCLRType
    {
        get
        {
            return typeof(SequentialFSM.IState);//这是你想继承的那个类
        }
    }

    public override Type AdaptorType
    {
        get
        {
            return typeof(Adaptor);//这是实际的适配器类
        }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);//创建一个新的实例
    }

    class Adaptor : SequentialFSM.IState, CrossBindingAdaptorType
    {
        readonly ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        public ILTypeInstance ILInstance { get { return instance; } }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        bool mOnEnterGot;
        IMethod mOnEnter;
        public void OnEnter()
        {
            if (!mOnEnterGot)
            {
                mOnEnter = instance.Type.GetMethod("OnEnter", null, null);
                mOnEnterGot = true;
            }
            if (mOnEnter != null)
            {
                appdomain.Invoke(mOnEnter, instance, null);
            }
        }

        bool mOnExitGot;
        IMethod mOnExit;
        public void OnExit()
        {
            if (!mOnExitGot)
            {
                mOnExit = instance.Type.GetMethod("OnExit", null, null);
                mOnExitGot = true;

            }
        
            if (mOnExit != null)
            {
                appdomain.Invoke(mOnExit, instance, null);
            }
        }

        bool mOnExecuteGot;
        IMethod mOnExecute;
        object[] objs = new object[1];
        public bool OnExecute(float deltaTime)
        {
            if (!mOnExitGot)
            {
                //参数类型列表
                List<IType> paramList = new List<IType>();
                IType itype = appdomain.GetType(typeof(float));
                paramList.Add(itype);
                mOnExit = instance.Type.GetMethod("OnExit", paramList, null);
                mOnExitGot = true;

            }

            if (mOnExit != null)
            {
                objs[0] = deltaTime;
                return (bool)appdomain.Invoke(mOnExit, instance, objs);
            }
            return default;
        }

        /*
bool mAddComponentGot = false;
IMethod mAddComponent = null;
IType[] genericArguments_mAddComponentGot = null; 
public override K AddComponent<K>()
{
   if (!mAddComponentGot)
   {
       IType itype = appdomain.GetType(typeof(K));
       genericArguments_mAddComponentGot = new IType[] { itype };

       mAddComponent = instance.Type.GetMethod("AddComponent", null, genericArguments_mAddComponentGot);
       mAddComponentGot = true;
   }
   if(mAddComponent!= null)
   {
       return (K)appdomain.Invoke(mAddComponent, instance, null);
   }
   return default;
}

bool mAddComponentGot2 = false;
IMethod mAddComponent2 = null;

public override IComponent AddComponent(IComponent component)
{
   if (!mAddComponentGot2)
   {
       IType itype = appdomain.GetType(typeof(IComponent));

       //参数类型列表
       List<IType> paramList = new List<IType>();

       paramList.Add(itype);

       mAddComponent2 = instance.Type.GetMethod("AddComponent", paramList, null);
       mAddComponentGot2 = true;
   }
   if (mAddComponent2 != null)
   {
       return (IComponent)appdomain.Invoke(mAddComponent2, instance, null);
   }
   return default;
}

bool mGetComponentGot = false;
IMethod mGetComponent = null;
IType[] genericArguments_GetComponent = null;
public override K GetComponent<K>() //where K : IComponent
{
   if (!mGetComponentGot)
   {
       IType itype = appdomain.GetType(typeof(K));
       genericArguments_GetComponent = new IType[] { itype };
       //mGetComponent = type.GetMethod("GenericMethod2", null, genericArguments_GetComponent);
       mGetComponent = instance.Type.GetMethod("GetComponent", null, genericArguments_GetComponent);
       mGetComponentGot = true;
   }
   if (mGetComponent != null)
   {
       return (K)appdomain.Invoke(mGetComponent, instance, null);
   }
   return default;
}
*/
    }
}
