using System;
namespace BombServer.Kernel
{
    public class UILoader
    {
        public UILoader()
        {
        }

        public T Factory<T>()where T : IEntiryForUI ,new()
        {
            return new T();
        }
    }


}