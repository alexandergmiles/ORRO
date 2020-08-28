using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Orro
{
    class Program
    {
        static void Main(string[] args)
        {
            XOREncryption enc = new XOREncryption();
            UDPConnection udpConnection = new UDPConnection();
            
            IPEndPoint bulbEndpoint = new IPEndPoint(new IPAddress(new byte[] { 192, 168, 1, 110 }), 9999);
            TP_Link_Kasa bulb = new TP_Link_Kasa(bulbEndpoint, enc, udpConnection);
            
            //The command the we need to execute
            //bulb.ExecuteCommand("{\"system\":{\"get_sysinfo\":\"\"}}");

            bulb.ExecuteCommand("{\"smartlife.iot.smartbulb.lightingservice\":{\"get_light_state\":\"\"}}");

            Console.ReadLine();
        }
    }
}
