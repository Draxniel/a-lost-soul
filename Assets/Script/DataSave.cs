using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataSave
{

    public static void saveCurrentGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData();
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("GAME SAVED ON FILE");
    }

    public static PlayerData loadCurrentGame()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("FILE NOT FOUND in "+path);
            return null;
        }
    }
    public static void deleteCurrentData()
    {
        Debug.Log("DATA DELETED");
        string path = Application.persistentDataPath + "/player.data";
        File.Delete(path);
    }
}
