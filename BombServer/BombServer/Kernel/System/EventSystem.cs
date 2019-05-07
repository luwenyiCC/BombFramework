using System;
using System.Collections.Generic;
using System.Reflection;

namespace BombServer.Kernel
{
    public class EventSystem : Component,ISystem
    {
        public Dictionary<int, IHandle> dispatcher;
        public EventSystem()
        {
            dispatcher = new Dictionary<int, IHandle>();
            Assembly assembly = Assembly.Load("BombServer");//加载项目
            var types = assembly.GetTypes();//取得项目下所有class的type
            foreach (Type type in types)
            {
                var attribute = type.GetCustomAttribute(typeof(HandleAttribut), false);//取得这个类的特性
                if (attribute is HandleAttribut eventHandle)//eventHandle 模式匹配
                {
                    IHandle execute = Activator.CreateInstance(type) as IHandle;//通过type实例化类
                    dispatcher[eventHandle.MsgType] = execute;
                }

            }
        }
        public void FireEvent(int msgType, object obj)
        {
            dispatcher[msgType]?.Execute(obj);
        }
        public void FireEvent(int msgType, byte[] buffer)
        {
            dispatcher[msgType]?.Execute(buffer);
        }
    }
}
