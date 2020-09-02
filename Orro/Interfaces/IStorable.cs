using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Orro.Interfaces
{
    interface IStorable
    {
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

        void ToJson<T>(T instance);
    }
}
