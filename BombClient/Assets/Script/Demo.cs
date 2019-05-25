using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BombFramework;
using System.IO;
using Google.Protobuf;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TcpSession tcpSession = new TcpSession();
        tcpSession.Connect();
        AccPwdRequet accPwdRequet = new AccPwdRequet
        {
            Account = "3333",
            Password = "1234"
        };
        byte[] bytes = ProtoTools.ToBuffer(accPwdRequet, (int)MSGID.Login);
        Debug.Log(bytes);
        
        //using (MemoryStream stream = new MemoryStream())
        //{

        //    //var cos = new CodedOutputStream(stream);
        //    // Save the person to a stream
        //    accPwdRequet.WriteTo(stream);


            
        //    bytes = stream.ToArray();
        //}
        //AccPwdRequet game2 = AccPwdRequet.Parser.ParseFrom(bytes);
        //Debug.Log(game2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
