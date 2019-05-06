using System;
using System.IO;
using System.Threading;
using AsyncNet.Tcp.Server;
using BombFramework;
using BombServer.Kernel;
using BombServer.Log;
using Google.Protobuf;

namespace BombServer.Network
{
    public class TcpComponent : Component
    {
        AsyncNetTcpServer server;

        public TcpComponent()
        {
            Debug.Log("ManagedThreadId:" + Thread.CurrentThread.ManagedThreadId);
            server = new AsyncNetTcpServer(12100);
            server.ConnectionClosed += (sender, e) => //当特定客户端/对等端连接关闭时触发
            { 
            };
            server.ConnectionEstablished += (sender, e) => //当新客户机/对等点连接到服务器时触发
            {
                var peer = e.RemoteTcpPeer;
                Debug.Log($"New connection from [{peer.IPEndPoint}]");
                Debug.Log("ManagedThreadId:" + Thread.CurrentThread.ManagedThreadId);


            };

            server.FrameArrived += (sender, e) =>//TCP帧从特定客户端/对等端到达时触发
            {
                Console.WriteLine($"Server received: {System.Text.Encoding.UTF8.GetString(e.FrameData)}");
                var peer = e.RemoteTcpPeer;
                //byte[] bytes=null;
               


                //foreach (var item in bytes)
                //{
                //    Console.WriteLine(item);

                //}
                //peer.Post(bytes);

                


            };
            server.RemoteTcpPeerExceptionOccured += (sender, e) =>//当处理特定客户机/对等点时发生错误时触发
            { 
            };
            server.ServerExceptionOccured += (sender, e) =>//当服务器出现问题时触发
            {
                 
            };
            server.ServerStarted += (sender, e) => //当服务器开始运行时触发
            {
                Console.WriteLine($"Server started on port: " + $"{e.ServerPort}");
            };
            server.UnhandledExceptionOccured += (sender, e) => //当未处理的错误发生时触发——例如，当事件订阅程序抛出异常时
            { 
            
            };

            server.StartAsync(CancellationToken.None);
        }

    }
}
