using UnityEngine;

namespace MW.Save
{
    public class Save : MonoBehaviour
    {
        [SerializeField] private SerializerType serializerType = SerializerType.Binary;

        private SaveData data = new();

        public object GetValue(string _key)
        {
            return data.Data.ContainsKey(_key) ? data.Data[_key] : null;
        }

        public void SetValue(string _key, object _value)
        {
            data.Data[_key] = _value;
        }

        public void SaveLocal()
        {
            getSerializer(serializerType).Serialize(data);
        }

        public void LoadLocal()
        {
            data = getSerializer(SerializerType.Binary).Deserialize<SaveData>();
            data ??= getSerializer(SerializerType.JSON).Deserialize<SaveData>();
        }

        public void SaveCloud()
        {
            Cloud.Save(data);
        }

        public void LoadCloud()
        {
            data = Cloud.Load<SaveData>().Result;
        }

        private SerializerBase getSerializer(SerializerType _serializerType)
        {
            return _serializerType switch
            {
                SerializerType.JSON => new SerializerJSON(),
                SerializerType.Binary => new SerializerBinary(),
                _ => null,
            };
        }
    }
}
