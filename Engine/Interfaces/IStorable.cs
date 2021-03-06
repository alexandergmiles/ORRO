﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Engine.Interfaces
{
    public interface IStorable
    {
        T FromJson<T>(string location);

        void ToJson(string location);
    }
}
