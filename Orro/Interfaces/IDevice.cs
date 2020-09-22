﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Orro.Interfaces
{
    interface IDevice : IStorable, IStreamable
    {
        IEncryption Encryption { get; }
        IConnector Connection { get; }
        IPEndPoint DeviceIP { get; }
        Func<string, Socket, IPEndPoint, string> CommunicationMethod { get; }
        void ExecuteCommand(ICommand command);
    }
}
