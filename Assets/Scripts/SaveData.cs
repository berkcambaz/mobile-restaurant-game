using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int gold;
    public int diamond;

    public static void Save(SaveData _data)
    {
        try
        {
            string json = JsonUtility.ToJson(_data);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/user.save", json);
        }
        catch (System.Exception) { }
    }

    public static SaveData Load()
    {
        SaveData data = null;

        try
        {
            string json = System.IO.File.ReadAllText(Application.persistentDataPath + "/user.save");
            data = JsonUtility.FromJson<SaveData>(json);
        }
        catch (System.Exception) { }

        return data;
    }
}
