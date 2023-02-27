using System.Collections.Generic;
using UnityEngine;

namespace MW.Save
{
    public class Save : MonoBehaviour
    {
        [SerializeField] private SerializerType serializerType = SerializerType.Binary;
        private SaveData data = new();

        private void Start()
        {
            SetValue("Float", 2f);
            SetValue("Int", 10);
            SetValue("String", "String");
        }

        [ContextMenu("Change values")]
        public void ChangeValues()
        {
            SetValue("Float", 4f);
            SetValue("Int", 20);
            SetValue("String", "strong");
        }

        public void SetValue(string _key, object _value)
        {
            data.Data[_key] = _value;
        }

        public object GetValue(string _key)
        {
            if (data.Data.ContainsKey(_key))
            {
                return data.Data[_key];
            }
            else
            {
                return null;
            }
        }

        [ContextMenu("Save local")]
        public void SaveLocal()
        {
            getSerializer(serializerType).Serialize(data);
        }

        [ContextMenu("Loadlocal")]
        public void LoadLocal()
        {
            data = getSerializer(SerializerType.Binary).Deserialize<SaveData>();
            data ??= getSerializer(SerializerType.JSON).Deserialize<SaveData>();

            DebugData();
        }

        private SerializerBase getSerializer(SerializerType _serializerType)
        {
            switch (_serializerType)
            {
                case SerializerType.JSON:
                    return new SerializerJSON();

                case SerializerType.Binary:
                    return new SerializerBinary();

                default:
                    return null;
            }
        }

        private void DebugData()
        {
            foreach (KeyValuePair<string, object> _value in data.Data)
            {
                Debug.Log(_value.Key + " " + _value.Value);
            }
        }
    }
}
