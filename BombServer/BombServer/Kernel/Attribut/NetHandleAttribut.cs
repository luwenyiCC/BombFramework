using System;
using BombFramework;

namespace BombServer.Kernel
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]//设置了定位参数和命名参数
    public class NetHandleAttribut : HandleAttribut
    {

        //public NetHandleAttribut(int msgType)
        //{
        //    this.msgType = msgType;

        //}
        public NetHandleAttribut(MSGID msgType)
        {
            this.msgType = (int)msgType;

        }
    }

}
