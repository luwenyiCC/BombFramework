using System;
using System.Net;
using System.Net.Sockets;

public class TcpSession
{
    public TcpSession()
    {
        IPAddress address = IPAddress.Parse("127.0.0.1");
        IPEndPoint iPEndPoint = new IPEndPoint(address, 12100);
        TcpClient tcp = new TcpClient();
        tcp.Connect(iPEndPoint);

    }
}
