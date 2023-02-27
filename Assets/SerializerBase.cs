using UnityEngine;

namespace MW.Save
{
    public abstract class SerializerBase
    {
        public abstract void Serialize(object _data);

        public abstract T Deserialize<T>();
    }
}