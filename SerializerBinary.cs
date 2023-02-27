using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MW.Save
{
    public class SerializerBinary : SerializerBase
    {
        private readonly string path = Application.persistentDataPath + "/save_data.save";

        public override void Serialize(object _data)
        {
            BinaryFormatter _binaryFormatter = new();

            try
            {
                FileStream _fileStream = File.Create(path);
                _binaryFormatter.Serialize(_fileStream, _data);
                _fileStream.Close();
            }
            catch (Exception _exception)
            {
                Debug.LogError("Error while serializing data: " + _exception.Message);
            }

        }

        public override T Deserialize<T>()
        {
            BinaryFormatter _binaryFormatter = new();
            T _data = default;

            try
            {
                FileStream _fileStream = File.Open(path, FileMode.Open);
                _data = (T) _binaryFormatter.Deserialize(_fileStream);
                _fileStream.Close();
            }
            catch (Exception _exception)
            {
                Debug.LogError($"Error while deserializing data: {_exception.Message}");
            }

            return _data;
        }
    }
}