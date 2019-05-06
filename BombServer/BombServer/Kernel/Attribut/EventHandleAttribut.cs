using System;
namespace BombServer.Kernel.Attribut
{
    public enum HandleType
    {
        None,
        Max
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]//设置了定位参数和命名参数
    public class EventHandleAttribut : Attribute
    {

        public HandleType handleType;
        public EventHandleAttribut(HandleType handleType)
        {
            this.handleType = handleType;

        }
    }

}
