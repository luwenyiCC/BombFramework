using System.Collections;
using System.Collections.Generic;
using System.IO;
using BombFramework;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Profiling;

public class ProtocolDemo : MonoBehaviour
{
    AppDomain appDomain;
    byte[] buffer = null;
    object obj;
    IMethod method;
    object[] pramas;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        byte[] dll = null;
        appDomain = new AppDomain();
        using (WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/HotFix_Project.dll"))
        {
            yield return www;
            dll = www.bytes;
        }
        using (System.IO.MemoryStream fs = new MemoryStream(dll))
        {
            //using (System.IO.MemoryStream p = new MemoryStream(pdb))
            {
                //appdomain.LoadAssembly(fs, p, new Mono.Cecil.Pdb.PdbReaderProvider());
                appDomain.LoadAssembly(fs, null, null);
            }
        }
        //object iltype = appDomain.Instantiate("HotFix_Project.TestProtocol");
        IType type = appDomain.LoadedTypes["HotFix_Project.TestProtocol"];
        //参数类型列表
        List<IType> paramList = new List<IType>();
        IType intType = appDomain.GetType(typeof(byte[]));

        paramList.Add(intType);
         method = type.GetMethod("ResponseMSG", paramList, null);
        //method = type.GetMethod("ResponseMSG", 1);
        obj = ((ILType)type).Instantiate();
        //appDomain.Invoke(method, obj, new object[] { dll });
        AccPwdRequet acc = new AccPwdRequet { Account = "444", Password = "5555"};
        byte[] bytes = ProtoTools.ToBuffer(acc);

        Debug.Log("bytes.Length=" + bytes.Length);
        pramas = new object[] { bytes };
        buffer = bytes;
    }

    // Update is called once per frame
    void Update()
    {
        if (buffer != null && method != null && obj != null)
        {

            //Debug.Log("调用成员方法");
            Profiler.BeginSample("---HotFix_Project");
            appDomain.Invoke("HotFix_Project.TestProtocol", "ResponseMSG", obj, pramas);
            Profiler.EndSample();
            Profiler.BeginSample("---No HotFix_Project");
            AccPwdRequet data = AccPwdRequet.Parser.ParseFrom(buffer);
            Profiler.EndSample();
            Profiler.BeginSample("---HotFix_Project Method Empty");
            appDomain.Invoke("HotFix_Project.TestProtocol", "MethodEmpty", obj, null);

            Profiler.EndSample();

        }

    }
}
