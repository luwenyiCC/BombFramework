using System;
namespace BombServer.Kernel.Attribut
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]//设置了定位参数和命名参数
    public class NetHandleAttribut : Attribute
    {

        public int msgType;
        public NetHandleAttribut(int msgType)
        {
            this.msgType = msgType;

        }
    }

}
