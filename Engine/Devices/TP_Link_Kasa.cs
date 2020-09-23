using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Engine.Interfaces;

namespace Engine.Devices
{
    public class TP_Link_Kasa : IDevice, IStreamable
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

        public string ExecuteCommand(ICommand command)
        {
            return command.Execute(this);   
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

        /// <summary>
        /// GetValuesFromDevice will get a specified value from the device. 
        /// </summary>
        /// <typeparam name="T">The return type of the command</typeparam>
        /// <returns></returns>
        public async Task<DataItem<T>>GetValuesFromDeviceAsync<T>()
        {
           return await Task.Run(() =>
           {
               return new DataItem<T>("Power", generateValues<T>());
           });
        }

        public T generateValues<T>()
        {
            Random rnd = new Random();
            return (T)Convert.ChangeType((rnd.NextDouble()), typeof(T));
        }
    }
}
