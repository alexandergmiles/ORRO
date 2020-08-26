using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Orro.Interfaces
{
    interface IConnector
    {
        //A type of connection to be used
        Socket CreateConnectionSocket();

        string SendQuery(string command);
    }
}
