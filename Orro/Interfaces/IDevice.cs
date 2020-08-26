using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Orro.Interfaces
{
    interface IDevice
    {
        IEncryption Encryption { get; }
        IConnector Connection { get; }
        IPEndPoint DeviceIP { get; }
        
        Func<string> CommunicationMethod { get; }
        void ExecuteCommand(string command);
    }
}
