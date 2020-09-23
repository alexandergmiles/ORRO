using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Commands
{
    public class Kasa_GetBulbInfo : ICommand
    {
        public string Execute(IDevice device)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //Parameterise the string, lol no parameters
            var parameterisedString = device.Encryption.ParameteriseCommandString(GetCommandString(), parameters);

            //Encrypt the command string
            var encryptedString = device.Encryption.EncryptCommand(parameterisedString);

            var socket = device.Connection.CreateConnectionSocket(device.DeviceIP);

            //Execuite the actual command
            var resultOfCommandEncrypted = device.CommunicationMethod.Invoke(encryptedString, socket, device.DeviceIP);

            var decryptedResult = device.Encryption.DecryptResponse(resultOfCommandEncrypted);

            return decryptedResult;
        }

        public string GetCommandString() => "{\"system\":{\"get_sysinfo\":\"\"}}";

    }
}
