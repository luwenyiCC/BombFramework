using System;
using BombFramework;
using UnityEngine;

namespace HotFix_Project
{
    public class TestProtocol
    {
        public TestProtocol()
        {
            Debug.Log("TestProtocol");
        }
        public void MethodEmpty()
        {
            //Debug.Log("MethodEmpty");

        }
        public void ResponseMSG(byte[] buffer)
        {
            //Debug.Log("ResponseMSG  " + buffer);
            //Debug.Log(buffer.Length);
            AccPwdRequet data = AccPwdRequet.Parser.ParseFrom(buffer);
            //if(data != null)
            //{
            //    Debug.Log(data.Account);
            //    Debug.Log(data.Password);

            //}

            
        }
    }

}
