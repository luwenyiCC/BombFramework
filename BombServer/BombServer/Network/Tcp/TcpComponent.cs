using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AsyncNet.Tcp.Remote;
using AsyncNet.Tcp.Server;
using BombServer.Kernel;

namespace BombServer.Network
{
    public class TcpComponent : Component
    {
        AsyncNetTcpServer server;

        Dictionary<int, IHandle> dispatcher = null;
        Dictionary<long, IRemoteTcpPeer> remoteTcpPeerMap = null;
        Dictionary<IPEndPoint, long> ipEndPointIDMap = null;
        public TcpComponent()
        {
            InitHandle();
            InitTcpServer();
        }
        public async Task BroadcastAsync(byte[] buffer)
        {
            await server.BroadcastAsync(buffer, server.ConnectedPeers);
        }
        public async Task SendAsync(byte[] buffer,long id)
        {
            bool success = await remoteTcpPeerMap[id]?.SendAsync(buffer );
            if(!success)
            {
                //TODO 发送成功异常
            }
        }
        void InitHandle()
        {
            dispatcher = new Dictionary<int, IHandle>();
            Assembly assembly = Assembly.Load("BombServer");//加载项目
            var types = assembly.GetTypes();//取得项目下所有class的type
            foreach (Type type in types)
            {
                var attribute = type.GetCustomAttribute(typeof(NetHandleAttribut), false);//取得这个类的特性
                if (attribute is NetHandleAttribut eventHandle)//eventHandle 模式匹配
                {
                    IHandle execute = Activator.CreateInstance(type) as IHandle;//通过type实例化类
                    dispatcher[eventHandle.MsgType] = execute;
                }
            }
        }
        void InitTcpServer()
        {
            remoteTcpPeerMap = new Dictionary<long, IRemoteTcpPeer>();
            ipEndPointIDMap = new Dictionary<IPEndPoint, long>();
            Debug.Log("ManagedThreadId:" + Thread.CurrentThread.ManagedThreadId);
            server = new AsyncNetTcpServer(12100);
            server.ConnectionClosed += (sender, e) => //当特定客户端/对等端连接关闭时触发
            { 
            };
            server.ConnectionEstablished += (sender, e) => //当新客户机/对等点连接到服务器时触发
            {
                IRemoteTcpPeer peer = e.RemoteTcpPeer;
                Debug.Log($"New connection from [{peer.IPEndPoint}]");
                Debug.Log("ManagedThreadId:" + Thread.CurrentThread.ManagedThreadId);
                long id = IdGenerater.GenerateId();
                remoteTcpPeerMap[id] = peer;
                ipEndPointIDMap[peer.IPEndPoint] = id;
            };

            server.FrameArrived += (sender, e) =>//TCP帧从特定客户端/对等端到达时触发
            {
                Console.WriteLine($"Server received: {System.Text.Encoding.UTF8.GetString(e.FrameData)}");
                var peer = e.RemoteTcpPeer;
                byte[] framedata = e.FrameData;
                int offser = 0;
                int remain = framedata.Length;
                int len = 0;
                int cmd = 0;
                while(remain > offser)
                {
                    offser += Utils.Decode32(framedata, offser, ref len);
                    offser += Utils.Decode32(framedata, offser, ref cmd);
                    //offser += Utils.Decode32(framedata, offser, ref cmd);
                    dispatcher[cmd]?.Execute(framedata, offser, len , ipEndPointIDMap[e.RemoteTcpPeer.IPEndPoint]);
                    offser += len;
                }



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
