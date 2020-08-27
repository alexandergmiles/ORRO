using System;
using System.Collections.Generic;
using System.Text;

namespace Orro.Interfaces
{
    interface IEncryption
    {
        string EncryptCommand(string commandString);
        string DecryptResponse(string responseString);
        string ParameteriseCommandString(string commandString, Dictionary<string, object> parameterValues);
    }
}
