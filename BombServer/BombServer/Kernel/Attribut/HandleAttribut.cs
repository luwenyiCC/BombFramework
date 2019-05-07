using System;
namespace BombServer.Kernel
{
    public abstract class HandleAttribut : Attribute
    {
        protected int msgType;

        public int MsgType { get => msgType; }
    }
}
