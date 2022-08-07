using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour
{
    public GameData gameData;

    public Text goldText;

    void OnEnable()
    {
        OnGoldChange(gameData.gold.value);
        gameData.gold.AddListener(OnGoldChange);
    }

    void OnDisable()
    {
        gameData.gold.RemoveListener(OnGoldChange);
    }

    private void OnGoldChange(int _gold)
    {
        goldText.text = _gold.ToString();
    }
}
