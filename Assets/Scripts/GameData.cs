using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public IntSignallable gold;
    public IntSignallable diamond;
    public GameTime gameTime;
    public IntValue maxOrderCount;

    public void SaveGameData()
    {
        SaveData data = new SaveData();

        data.gold = gold.value;
        data.diamond = diamond.value;

        SaveData.Save(data);
    }

    public void LoadGameData()
    {
        SaveData data = SaveData.Load();
        if (data == null) return;

        gold.value = data.gold;
        diamond.value = data.diamond;
    }
}
