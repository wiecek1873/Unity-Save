using System;
using System.Collections.Generic;

namespace MW.Save
{
    [Serializable]
    public class SaveData
    {
        public Dictionary<string, object> Data = new();
    }
}