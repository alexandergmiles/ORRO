using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace Orro.Interfaces
{
    interface IDevice
    {
        IEncryption Encryption { get; }
        IConnector Connection { get; }

        [JsonIgnore]
        IPEndPoint DeviceIP { get; }
        [JsonIgnore]
        Func<string, Socket, IPEndPoint, string> CommunicationMethod { get; }
        void ExecuteCommand(string command);
        T FromJson<T>(string JSON)
        {
            var result = JsonConvert.DeserializeObject<T>(JSON);

            if (result is T)
            {
                return result;
            }
            else
            {
                throw new Exception($"This should ony be used to access {typeof(T)} devices!");
            }
        }

        void ToJson(IDevice instance)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"c:\bulbs\bulbs.json"))
            {
                var result = JsonConvert.SerializeObject(instance, Formatting.Indented, new DeviceConverter());
                file.Write(result);
            }
        }
    }
}
