using System;
using System.IO;
using System.Threading;
using AsyncNet.Tcp.Server;
using BombFramework;
using BombServer.Kernel;
using Google.Protobuf;

namespace BombServer.Network
{
    public class TcpComponent : Component
    {
        AsyncNetTcpServer server;

        public TcpComponent()
        {

            server = new AsyncNetTcpServer(12100);
            server.ConnectionClosed += (sender, e) => //当特定客户端/对等端连接关闭时触发
            { 
            };
            server.ConnectionEstablished += (sender, e) => //当新客户机/对等点连接到服务器时触发
            {
                var peer = e.RemoteTcpPeer;
                Console.WriteLine($"New connection from [{peer.IPEndPoint}]");

                var hello = "Hello from server!";
                var bytes = System.Text.Encoding.UTF8.GetBytes(hello);
                peer.Post(bytes);
            };

            server.FrameArrived += (sender, e) =>//TCP帧从特定客户端/对等端到达时触发
            {
                Console.WriteLine($"Server received: {System.Text.Encoding.UTF8.GetString(e.FrameData)}");
                var peer = e.RemoteTcpPeer;
                byte[] bytes=null;
               
                using (MemoryStream stream = new MemoryStream())
                {
                    RPC rpc = new RPC();
                    rpc.ID = 1;

                    // Save the person to a stream
                    rpc.WriteTo(stream);
                    IMessage


                    bytes = stream.ToArray();
                }
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    RPC rpc = new RPC();
                    rpc.MergeFrom(stream);



                    Console.WriteLine(rpc.ID);
                }

                foreach (var item in bytes)
                {
                    Console.WriteLine(item);

                }
                peer.Post(bytes);

                


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
