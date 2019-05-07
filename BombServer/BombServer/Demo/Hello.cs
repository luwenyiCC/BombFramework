using System;
//using BombServer.Kernel.Attribut;
using BombServer.Kernel;

namespace BombServer.Demo
{
    [EventHandleAttribut(HandleType.Hello)]
    public class Hello : EventHandle
    {
        public Hello()
        {
        }

        public override void Execute(object obj)
        {
            Debug.Log(obj);
            //throw new NotImplementedException();
        }
    }
}
