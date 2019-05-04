using System;
namespace BombServer.Kernel
{
    public interface IComponent
    {
        Object GetParent();
        void SetParent(Object obj);
    }
}
