using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

public class MyInheritanceAdapter : CrossBindingAdaptor
{


    public override Type BaseCLRType { get { return typeof(TestClassBase); } }

    public override Type AdaptorType { get { return typeof(Adaptor ); } }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);//创建一个新的实例

    }

    class Adaptor : TestClassBase, CrossBindingAdaptorType
    {
        public ILTypeInstance ILInstance { get { return instance; } }
        AppDomain appdomain;
        ILTypeInstance instance;
        IMethod method_TestAbstract;
        bool is_method_TestAbstract;
        //缓存这个数组来避免调用时的GC Alloc
        object[] param1 = new object[1];
        public Adaptor()
        {

        }
        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }
        //你需要重写所有你希望在热更脚本里面重写的方法，并且将控制权转到脚本里去
        public override void TestAbstract(int gg)
        {
            if(!is_method_TestAbstract)
            {
                method_TestAbstract = instance.Type.GetMethod("TestAbstract", 1);
                is_method_TestAbstract = true;
            }
            if(method_TestAbstract != null)
            {
                param1[0] = gg;
                appdomain.Invoke(method_TestAbstract, instance, param1);//没有参数建议显式传递null为参数列表，否则会自动new object[0]导致GC Alloc
            }
        }

        IMethod mTestVirtual;
        bool mTestVirtualGot;
        bool isTestVirtualInvoking = false;
        public override void TestVirtual(string str)
        {
            if (!mTestVirtualGot)
            {
                mTestVirtual = instance.Type.GetMethod("TestVirtual", 1);
                mTestVirtualGot = true;
            }
            //对于虚函数而言，必须设定一个标识位来确定是否当前已经在调用中，否则如果脚本类中调用base.TestVirtual()就会造成无限循环，最终导致爆栈

            if (mTestVirtual != null && !isTestVirtualInvoking)
            {
                isTestVirtualInvoking = true;
                param1[0] = str;
                appdomain.Invoke(mTestVirtual, instance, param1);
                isTestVirtualInvoking = false;
            }
        }
        //public override void TestVirtual(string str)
        //{
        //    if (!mTestVirtualGot)
        //    {
        //        mTestVirtual = instance.Type.GetMethod("TestVirtual", 1);
        //        mTestVirtualGot = true;
        //    }
        //    //对于虚函数而言，必须设定一个标识位来确定是否当前已经在调用中，否则如果脚本类中调用base.TestVirtual()就会造成无限循环，最终导致爆栈
        //    if (mTestVirtual != null && !isTestVirtualInvoking)
        //    {
        //        isTestVirtualInvoking = true;
        //        param1[0] = str;
        //        appdomain.Invoke(mTestVirtual, instance, param1);
        //        isTestVirtualInvoking = false;
        //    }
        //    else
        //        base.TestVirtual(str);
        //}
        IMethod mGetValue;
        bool mGetValueGot;
        bool isGetValueInvoking = false;
        //public override int Value
        //{
        //    get
        //    {
        //        if (!mGetValueGot)
        //        {
        //            //属性的Getter编译后会以get_XXX存在，如果不确定的话可以打开Reflector等反编译软件看一下函数名称
        //            mGetValue = instance.Type.GetMethod("get_Value", 1);
        //            mGetValueGot = true;
        //        }
        //        //对于虚函数而言，必须设定一个标识位来确定是否当前已经在调用中，否则如果脚本类中调用base.Value就会造成无限循环，最终导致爆栈
        //        if (mGetValue != null && !isGetValueInvoking)
        //        {
        //            isGetValueInvoking = true;
        //            var res = (int)appdomain.Invoke(mGetValue, instance, null);
        //            isGetValueInvoking = false;
        //            return res;
        //        }
        //        else
        //            return base.Value;
        //    }
        //}

        //public override string ToString()
        //{
        //    IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
        //    m = instance.Type.GetVirtualMethod(m);
        //    if (m == null || m is ILMethod)
        //    {
        //        return instance.ToString();
        //    }
        //    else
        //        return instance.Type.FullName;
        //}
    }
}
