using System;
using System.Collections.Generic;
using System.Text;

namespace Orro.Interfaces
{
    interface IEncryption
    {
        string EncryptCommand(string commandString);
        string DecryptResponse(string responseString);
        public string ParameteriseCommandString(string commandString, Dictionary<string, string> parameterValues)
        {
            foreach (var parameter in parameterValues)
            {
                commandString = commandString.Replace(parameter.Key, parameter.Value);
            }
            return commandString;
        }
    }
}
