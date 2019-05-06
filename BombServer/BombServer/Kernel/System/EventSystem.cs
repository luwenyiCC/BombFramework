using System;
using System.Collections.Generic;
using System.Reflection;
using BombServer.Kernel.Attribut;
using BombServer.Kernel.Interface;

namespace BombServer.Kernel.System
{
    public class EventSystem
    {
        public Dictionary<int, IHandle> dispatcher;
        public EventSystem()
        {
            dispatcher = new Dictionary<int, IHandle>();
            Assembly assembly = Assembly.Load("BombServer");//加载项目
            var types = assembly.GetTypes();//取得项目下所有class的type
            foreach (Type type in types)
            {
                var attribute = type.GetCustomAttribute(typeof(NetHandleAttribut), false);//取得这个类的特性
                if (attribute != null)
                {
                    if (attribute is NetHandleAttribut eventHandle)//eventHandle 模式匹配
                    {
                        IHandle execute = Activator.CreateInstance(type) as IHandle;//通过type实例化类
                        dispatcher[eventHandle.msgType] = execute;
                    }
                }
            }
        }

    }
}
