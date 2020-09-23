using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Engine.Interfaces
{
    public interface IConnector
    {
        //A type of connection to be used
        Socket CreateConnectionSocket(IPEndPoint deviceIP);
    }
}
