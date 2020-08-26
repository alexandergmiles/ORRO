using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Orro.Interfaces;

namespace Orro
{
    class TP_Link_Kasa : IDevice
    {
        public IPEndPoint DeviceIP { get; }

        public IEncryption Encryption { get; }

        public IConnector Connection { get; }

        public Func<string> CommunicationMethod { get; }

        public string ConnectionMethod(Func<string> commandString)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommand(string command)
        {
            var parameterisedString = .ParameteriseCommandString(command);
            var encryptedString = Encryption.EncryptCommand(parameterisedString);
            
        }
    }
}
