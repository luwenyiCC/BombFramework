using System;
using System.Collections.Generic;

namespace BombServer.Kernel
{
    public class Entity : IEntiry
    {
        public Entity()
        {
        }
        protected Dictionary<Type, IComponent> componentDict = new Dictionary<Type, IComponent>();
        public IComponent AddComponent(IComponent component)
        {
            Type type = component.GetType();
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, component: {type.Name}");
            }

            component.SetParent(this);

            this.componentDict.Add(type, component);
            return component;
        }

        /// <summary>
        ///  new() 检查是否有空的构造函数
        /// </summary>
        /// <returns>The component.</returns>
        /// <typeparam name="K">The 1st type parameter.</typeparam>
        public virtual K AddComponent<K>() where K : IComponent, new()
        {
            Type type = typeof(K);
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist component: {typeof(K).Name}");
            }

            K component = new K();

            this.componentDict.Add(type, component);
            return component;
        }

        public IComponent GddComponent<K>()
        {
            Type type = typeof(K);
            //IComponent component;
            this.componentDict.TryGetValue(type, out IComponent component);
            return component;
        }

    }
}
