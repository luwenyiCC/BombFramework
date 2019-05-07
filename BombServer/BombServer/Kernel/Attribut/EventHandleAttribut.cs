using System;
namespace BombServer.Kernel
{
    /// <summary>
    /// 游戏内消息号100000起步
    /// </summary>
    public enum HandleType
    {
        None=100000,
        Hello,
        Max
    }
    [AttributeUsage(AttributeTargets.Class  , Inherited = false)]//设置了定位参数和命名参数
    public class EventHandleAttribut : HandleAttribut
    {


        public EventHandleAttribut(HandleType handleType)
        {
            this.msgType  = (int)handleType;

        }
    }

}
