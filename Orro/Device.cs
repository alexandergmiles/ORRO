using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Orro.Interfaces;

namespace Orro
{
    class Device
    {
        IEncryption Encryption { get; }
        IConnector Connection { get; }
        public IPEndPoint DeviceIP { get; }

        public Device(IEncryption encryptor, IConnector connector, IPEndPoint deviceIP)
        {
            Encryption = encryptor;
            Connection = connector;
            DeviceIP = deviceIP;
        }


    }
}

/*
 *{
 *"TP-Link Bulb": {
 *     //How commands are encrypted
 *     "EncryptionMethod": "XOR",
 *     //How we connect to the given device
 *     "Connection": "UDPSocket",
 *     //The properties we have available for the device
 *     "Properties": [
 *          "LightState": {Lightstate object}
 *     ],
 *     //These are the methods that can be used on the device
 *     "MethodSet": [
 *         "ConnectionType": "TP-Link-Kasa",
 *         "ReadingType": "Socket"
 *     ]
 *} 
 *
 * 
 * }
 */