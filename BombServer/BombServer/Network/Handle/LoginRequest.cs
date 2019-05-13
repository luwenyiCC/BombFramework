using System;
using BombFramework;
using BombServer.Kernel;

namespace BombServer.Network.Handle
{
    [NetHandleAttribut(MSGID.Login)]
    public class LoginRequest : NetHandle<AccPwdRequet>
    {


        public override void Execute(byte[] _data)
        {
            Init(_data);
            //MongoDB.Driver
            throw new NotImplementedException();
        }
    }
}
