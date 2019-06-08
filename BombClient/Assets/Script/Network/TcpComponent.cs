using System.Collections;
using System.Collections.Generic;
using BombServer.Kernel;

public class TcpComponent : Component
{
    TcpSession tcpSession;

    public TcpComponent()
    {
       tcpSession = new TcpSession();

    }
    public TcpSession Session
    {
        get
        {
            return tcpSession;
        }
    }
}
