using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DevKacper.SaveSystem
{
    public class SerializationManager
    {
        public static bool Save(string fileName, object data, string fileSuffix = ".save")
        {
            BinaryFormatter formatter = GetBinaryFormatter();

            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            string path = Application.persistentDataPath + "/saves/" + fileName + fileSuffix;
            FileStream file = File.Create(path);
            formatter.Serialize(file, data);
            file.Close();

            return true;
        }

        public static object Load(string fileName)
        {
            string path = Application.persistentDataPath + "/saves/" + fileName;
            if (!File.Exists(path))
            {
                return null;
            }

            BinaryFormatter formater = GetBinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            try
            {
                object save = formater.Deserialize(file);
                file.Close();
                return save;
            }
            catch
            {
                Debug.Log($"Failed to load file at {path}");
                file.Close();
                return null;
            }
        }

        public static bool Delete(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            File.Delete(path);
            return true;
        }

        private static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SurrogateSelector selector = new SurrogateSelector();

            Vector3SerializationSurrogate vector3SerializationSurrogate = new Vector3SerializationSurrogate();
            Vector2SerializationSurrogate vector2SerializationSurrogate = new Vector2SerializationSurrogate();
            QuaternionSerializationSurrogate quaternionSerializationSurrogate = new QuaternionSerializationSurrogate();
            TransformSerializationSurrogate transformSerializationSurrogate = new TransformSerializationSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SerializationSurrogate);
            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2SerializationSurrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionSerializationSurrogate);
            selector.AddSurrogate(typeof(Transform), new StreamingContext(StreamingContextStates.All), transformSerializationSurrogate);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}