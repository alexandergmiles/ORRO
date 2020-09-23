using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    //T is the type
    public class DataItem<T>
    {
        string Name { get; set; }
        T Value { get; set; }
        public DataItem(string name, T value) => (Name, Value) = (name, value);
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
