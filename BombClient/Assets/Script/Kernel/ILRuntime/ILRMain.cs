
using System.Collections.Generic;
using BombServer.Kernel;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using UnityEngine;
using Component = BombServer.Kernel.Component;
//using UnityEngine;

public class ILRMain : Component
{
    public ILRMain()
    {
        Init();
    }
    AppDomain appDomain;
    public void Init()
    {
        //首先实例化ILRuntime的AppDomain，AppDomain是一个应用程序域，每个AppDomain都是一个独立的沙盒

        appDomain = new AppDomain();
        byte[] dll = null;
        using (WWW www = new WWW(PathTools.ILRuntimeDLL))
        {
            while (!www.isDone || www.error != null) { }
            if (www.error != null)
            {
                Debug.LogError(www.error);
            }
            dll = www.bytes;
        }
        if(dll != null)
        {
            using(System.IO.MemoryStream ms = new System.IO.MemoryStream(dll))
            {
                appDomain.LoadAssembly(ms, null,null);
            }
        }
        InitializeILRuntime();
        OnHotFixLoaded();
    }

    void InitializeILRuntime()
    {
        //这里做一些ILRuntime的注册，这里应该写CLR绑定的注册，
        ILRuntime.Runtime.Generated.CLRBindings.Initialize(appDomain);

    }
    void OnHotFixLoaded()
    {
        ///*
        IType itype = appDomain.LoadedTypes["HotFix_Project.HotFixMain"];
        object instance = ((ILType)itype).Instantiate();
        IMethod method = itype.GetMethod("Main", 1);
        //参数类型列表
        //List<IType> paramList = new List<IType>
        //{
        //    appDomain.GetType(typeof(string))
        //};
        ////根据方法名称和参数类型列表获取方法
        //IMethod method = itype.GetMethod("Main", paramList, null);
        appDomain.Invoke(method, instance, "123");
        //*/
        //IType itype = appDomain.LoadedTypes["HotFix_Project.HotFixMain"];
        //object instance = ((ILType)itype).Instantiate();
        //IMethod method = itype.GetMethod("Test", 0);
        //appDomain.Invoke(method, instance, null);


    }

}
