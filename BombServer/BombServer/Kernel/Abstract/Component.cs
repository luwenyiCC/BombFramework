using System;
namespace BombServer.Kernel
{
    public abstract class Component : IComponent
    {
        object parent;

        public object GetParent()
        {
            return parent;
        }

        public void SetParent(object obj)
        {
            parent = obj;
        }
    }
}
