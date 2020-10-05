using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IStreamable
    {
        public Task<DataItem<T>> GetValuesFromDeviceAsync<T>();
        public IEnumerable<DataItem<T>> StreamValuesFromDevice<T>();
    }
}
