using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Orro.Interfaces;

namespace Orro
{
    class TP_Link_Kasa : IDevice
    {
        public IPEndPoint DeviceIP { get; }

        public IEncryption Encryption { get; }

        public IConnector Connection { get; }

        public Func<string, Socket, IPEndPoint, string> CommunicationMethod { get; }

        public TP_Link_Kasa(IPEndPoint deviceIP, IEncryption encryption, IConnector connection)
        {
            DeviceIP = deviceIP;
            Encryption = encryption;
            Connection = connection;
            CommunicationMethod = DefaultCommunicationMethod;
        }

        public TP_Link_Kasa(IPEndPoint deviceIP, IEncryption encryption, IConnector connection, Func<string, Socket, IPEndPoint, string> commMethod)
        {
            DeviceIP = deviceIP;
            Encryption = encryption;
            Connection = connection;
            CommunicationMethod = commMethod;
        }

        public void ExecuteCommand(string command)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            //Parameterise the string, lol no parameters
            var parameterisedString = Encryption.ParameteriseCommandString(command, parameters);
            
            //Encrypt the command string
            var encryptedString = Encryption.EncryptCommand(parameterisedString);
            
            var socket = Connection.CreateConnectionSocket(DeviceIP);
            
            //Execuite the actual command
            var resultOfCommandEncrypted = CommunicationMethod.Invoke(encryptedString, socket, DeviceIP);
            
            var decryptedResult = Encryption.DecryptResponse(resultOfCommandEncrypted);

            Console.WriteLine(decryptedResult);
        }

        private string DefaultCommunicationMethod(string command, Socket socket, IPEndPoint deviceIP)
        {
            //Prepare the data
            var dataToSend = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes(command));

            //Send the data byte[] to the endpoint we created previously
            socket.SendTo(dataToSend, new IPEndPoint(deviceIP.Address, deviceIP.Port));

            //The buffer we're going to read the data into
            byte[] buffer = new byte[1024];

            //Load the data from the response into the buffer
            //result holds the number of bits read
            var result = socket.Receive(buffer);

            //Get the resposne string from the string
            return Encoding.GetEncoding("ISO-8859-1").GetString(buffer, 0, result);
        }

        public void ToJson<T>(T instance)
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
