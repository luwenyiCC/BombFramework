using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpSession
{
    TcpClient tcpClient;
    class NetworkObject
    {
        public TcpClient tcpClient;
        public byte[] buffer;
    }
    public TcpSession()
    {


    }
    public void Connect()
    {
        IPAddress address = IPAddress.Parse("127.0.0.1");
        //IPEndPoint iPEndPoint = new IPEndPoint(address, 12100);
        tcpClient = new TcpClient();
        //tcp.Connect(iPEndPoint);
        tcpClient.BeginConnect(address, 12100, (ar) =>
        {
            UnityEngine.Debug.Log("连接上服务器");
            tcpClient = (TcpClient)ar.AsyncState;
            tcpClient.EndConnect(ar);
            {
                Send(Encoding.UTF8.GetBytes("hello"));
            }
            if (tcpClient.Connected)
            {
                NetworkStream stream = tcpClient.GetStream();
                if (stream.CanRead)
                {

                    NetworkObject networkObject = new NetworkObject();
                    networkObject.tcpClient = tcpClient;
                    networkObject.buffer = new byte[tcpClient.ReceiveBufferSize];
                    stream.BeginRead(networkObject.buffer, 0, tcpClient.ReceiveBufferSize, new AsyncCallback(AsyncReadCallBack), networkObject);
                }
            }
        }, tcpClient);
    }
    public void Send(byte[] buffer)
    {
        if (tcpClient!= null && tcpClient.Connected)
        {
            NetworkStream networkStream = tcpClient.GetStream();
            networkStream.BeginWrite(buffer, 0, buffer.Length, (ar) =>
            {
                NetworkStream ns = (NetworkStream)ar.AsyncState;
                ns.EndWrite(ar);
            }, networkStream);
        }


    }
    private void AsyncReadCallBack(IAsyncResult iar)
    {
        NetworkObject networkStream = (NetworkObject)iar.AsyncState;
        if ((networkStream == null) || (!networkStream.tcpClient.Connected)) return;
        int NumOfBytesRead;
        NetworkStream ns = networkStream.tcpClient.GetStream();
        NumOfBytesRead = ns.EndRead(iar);
        if (NumOfBytesRead > 0)
        {
            byte[] buffer = new byte[NumOfBytesRead];
            Array.Copy(networkStream.buffer, 0, buffer, 0, NumOfBytesRead);


            //byte[] byteData = Encoding.ASCII.GetBytes(data);

            //string msg = Encoding.UTF8.GetString(buffer);
            //byte[] bytes = null;
            //using (MemoryStream stream = new MemoryStream())
            //{

            //    RPC rpc = new RPC();
            //    rpc.ID = 1;

            //    // Save the person to a stream
            //    rpc.WriteTo(stream);
            //    bytes = stream.ToArray();
            //}
            //UnityEngine.Debug.Log(msg);
            ns.BeginRead(networkStream.buffer, 0, networkStream.buffer.Length, new AsyncCallback(AsyncReadCallBack), networkStream);
        }
        else
        {
            //NOTE 连接关闭
            UnityEngine.Debug.Log("连接关闭");

            ns.Close();
            networkStream.tcpClient.Close();
            ns = null;
            networkStream = null;
        }
    }
}
