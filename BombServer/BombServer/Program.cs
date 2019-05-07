using System;
using System.Threading;
using BombServer.Kernel;
using BombServer.Network;
using Google.Protobuf;
namespace BombServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //哈哈哈
            // 异步方法全部回调到主线程
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            Game.Instance.AddComponent<TcpComponent>();
            Game.Instance.AddComponent<EventSystem>();

            while (true)
            {
                Thread.Sleep(1);
                try
                {
                    OneThreadSynchronizationContext.Instance.Update();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
