using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Engine
{
    public class UDPConnection : IConnector
    {
        Socket IConnector.CreateConnectionSocket(IPEndPoint deviceIP)
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
    }
}
