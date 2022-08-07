using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondController : MonoBehaviour
{
    public GameData gameData;

    public Text diamondText;

    void OnEnable()
    {
        OnDiamondChange(gameData.diamond.value);
        gameData.diamond.AddListener(OnDiamondChange);
    }

    void OnDisable()
    {
        gameData.diamond.RemoveListener(OnDiamondChange);
    }

    private void OnDiamondChange(int _diamond)
    {
        diamondText.text = _diamond.ToString();
    }
}
