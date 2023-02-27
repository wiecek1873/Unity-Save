using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace MW.Save
{
    public class SerializerJSON : SerializerBase
    {
        private readonly string path = Application.persistentDataPath + "/save_data.json";

        public override void Serialize(object _data)
        {
            string _json = JsonConvert.SerializeObject(_data, Formatting.Indented);

            try
            {
                File.WriteAllText(path, _json);
            }
            catch (Exception _exception)
            {
                Debug.LogError($"Error while serializing data: {_exception.Message}");
            }
        }

        public override T Deserialize<T>()
        {
            try
            {
                string _json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(_json);
            }
            catch (Exception _exception)
            {
                Debug.LogError($"Error while deserializing data: {_exception.Message}");
                return default;
            }
        }
    }
}