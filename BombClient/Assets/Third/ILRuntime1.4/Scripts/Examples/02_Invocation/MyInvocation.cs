//using System;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ILRuntime.Runtime.Enviorment;
using System;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Intepreter;

public class MyInvocation : MonoBehaviour
{
    AppDomain appdomain;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadHotFixAssembly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadHotFixAssembly()
    {
        //首先实例化ILRuntime的AppDomain，AppDomain是一个应用程序域，每个AppDomain都是一个独立的沙盒
        appdomain = new AppDomain();
        //正常项目中应该是自行从其他地方下载dll，或者打包在AssetBundle中读取，平时开发以及为了演示方便直接从StreammingAssets中读取，
        //正式发布的时候需要大家自行从其他地方读取dll

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //这个DLL文件是直接编译HotFix_Project.sln生成的，已经在项目中设置好输出目录为StreamingAssets，在VS里直接编译即可生成到对应目录，无需手动拷贝
#if UNITY_ANDROID
        WWW www = new WWW(Application.streamingAssetsPath + "/HotFix_Project.dll");
#else
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll");
#endif
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
            UnityEngine.Debug.LogError(www.error);
        byte[] dll = www.bytes;
        www.Dispose();
        using (System.IO.MemoryStream fs = new MemoryStream(dll))

        {
            appdomain.LoadAssembly(fs, null, null);

        }

        InitializeILRuntime();
        OnHotFixLoaded();
    }

    private void OnHotFixLoaded()
    {

        appdomain.Invoke("HotFix_Project.InstanceClass", "StaticFunTest", null, null);


        //IType type = appdomain.LoadedTypes ("HotFix_Project.InstanceClass");
        IType type = appdomain.LoadedTypes["HotFix_Project.InstanceClass"];
        IMethod method = type.GetMethod("StaticFunTest", 0);
        appdomain.Invoke(method,null,null);

        Debug.Log("指定参数类型来获得IMethod");
        IType intType = appdomain.GetType(typeof(int));


        //参数类型列表
        List<IType> paramList = new List<IType>();

        paramList.Add(intType);
        IMethod method2 = type.GetMethod("StaticFunTest2", paramList,null);
        appdomain.Invoke(method2, null, 911);

        Debug.Log("实例化热更里的类");
        //第一种方式

        ILTypeInstance obj = appdomain.Instantiate("HotFix_Project.InstanceClass", new object[] { 111 });
        //第二种方式
        object obj2 = ((ILType)type).Instantiate();
        Debug.Log("调用成员方法");
        int id = (int)appdomain.Invoke("HotFix_Project.InstanceClass", "get_ID", obj, null);
        Debug.Log("!! HotFix_Project.InstanceClass.ID = " + id);
        id = (int)appdomain.Invoke("HotFix_Project.InstanceClass", "get_ID", obj2, null);
        Debug.Log("!! HotFix_Project.InstanceClass.ID = " + id);
        Debug.Log("!! cache method  StaticFunTest :");
        appdomain.Invoke(method, obj, null);

        Debug.Log("调用泛型方法");

        IType stringType = appdomain.GetType(typeof(string));
        IType[] genericArguments = { stringType };
        appdomain.InvokeGenericMethod("HotFix_Project.InstanceClass", "GenericMethod", genericArguments, null,"string generic method" );

        Debug.Log("获取泛型方法的IMethod");
        paramList.Clear();
        paramList.Add(intType);
        genericArguments = new IType []{ intType };
        method = type.GetMethod("GenericMethod", paramList, genericArguments);
        appdomain.Invoke(method,obj,300);

        Debug.Log("获取泛型方法的IMethod 2");
        genericArguments = new IType[] { intType };
        method = type.GetMethod("GenericMethod2", null, genericArguments);
        appdomain.Invoke(method, obj, null);

        Debug.Log("获取泛型方法的IMethod 3");
        genericArguments = new IType[] { intType };
        method = obj.Type.GetMethod("GenericMethod3", null, genericArguments);
        appdomain.Invoke(method, obj, null);
    }

    void InitializeILRuntime()
    {
        //这里做一些ILRuntime的注册，这个示例暂时没有需要注册的

    }
}
