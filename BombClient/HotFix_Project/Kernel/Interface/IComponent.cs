using System;
namespace HotFix_Project.Kernel
{
    public interface IComponent
    {
        Object GetParent();
        void SetParent(Object obj);
        void Dispose();
    }
}
