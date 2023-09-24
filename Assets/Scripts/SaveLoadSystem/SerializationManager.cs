using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoadSystem
{
    public class SerializationManager
    {
        public static bool Save(string saveName, object dataToSave)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (Directory.Exists(Application.persistentDataPath + "/saves") == false)
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            string savePath = Application.persistentDataPath + "/saves/" + saveName + ".save";

            FileStream fileStream = File.Create(savePath);
            binaryFormatter.Serialize(fileStream, dataToSave);
            fileStream.Close();

            return true;
        }
        public static object Load(string saveName)
        {
            string savePath = Application.persistentDataPath + "/saves/" + saveName + ".save";
            if (File.Exists(savePath) == false)
            {
                Debug.Log("Loading file does not exists");
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);

            try
            {
                object loadedData = binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                return loadedData;
            }
            catch
            {
                Debug.LogError("Failed to load " + saveName);
                return null;
            }
        }
    }
}
