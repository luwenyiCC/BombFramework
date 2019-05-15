using System;
using BombFramework;
using BombServer.Kernel;

namespace BombServer.Network.Handle
{
    [NetHandleAttribut(MSGID.Login)]
    public class LoginRequest : NetHandle<AccPwdRequet>
    {


        public override void Execute(byte[] _data,int offset,int len,long id)
        {
            Init(_data,offset ,len);
            Debug.Log(id);
            Debug.Log(data);
            //MongoDB.Driver
            throw new NotImplementedException();
        }
    }
}
