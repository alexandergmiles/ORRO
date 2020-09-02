using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Orro.Interfaces
{
    interface IStorable
    {
        T FromJson<T>(string location);

        void ToJson<T>(T instance, string location);
    }
}
