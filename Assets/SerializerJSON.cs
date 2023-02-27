using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace MW.Save
{

    public class SerializerJSON : SerializerBase
    {
        private readonly string path = Application.persistentDataPath + "/save_data.json"; // ustawienie œcie¿ki do zapisu danych w folderze AppData

        public override void Serialize(object _data)
        {
            string _json = JsonConvert.SerializeObject(_data, Formatting.Indented);
            File.WriteAllText(path, _json);
        }

        public override T Deserialize<T>()
        {
            string _json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(_json);
        }
    }
}