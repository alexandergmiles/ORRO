using Newtonsoft.Json;
using Engine.Commands;
using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Engine.Devices;

namespace Orro
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Engine.Interfaces.IEncryption enc = new Engine.XOREncryption();
            Engine.Interfaces.IConnector udpConnection = new Engine.UDPConnection();
            IPEndPoint bulbEndpoint = new IPEndPoint(new IPAddress(new byte[] { 192, 168, 1, 110 }), 9999);
            
            Engine.Devices.TP_Link_Kasa bulb = new Engine.Devices.TP_Link_Kasa(bulbEndpoint, enc, udpConnection, "test");
            
            //IHub hub = new AWSHub();
            //hub.Add(bulb);

            //Get bulb up time as a double#

            Console.WriteLine(await bulb.GetValuesFromDeviceAsync<string>());
            //What a cute means of storage
            //bulb.ToJson(@"C:/bulb/bulbs.json");

            ICommand getBulbLightInfo = new Engine.Commands.Kasa_GetBulbInfo();
            
            bulb.ExecuteCommand(getBulbLightInfo);
            foreach (var item in bulb.StreamValuesFromDevice<Double>())
            {
                Console.WriteLine(item);
            }
            //bulb.ExecuteCommand("{\"smartlife.iot.smartbulb.lightingservice\":{\"get_light_state\":\"\"}}");

            Console.ReadLine();
        }
    }
}
