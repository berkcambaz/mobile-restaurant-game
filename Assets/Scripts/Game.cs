using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameData gameData;

    public GameEvent onGameOpenEvent;
    public GameEvent onGameCloseEvent;

    void Start()
    {
        onGameOpenEvent.Dispatch();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            onGameCloseEvent.Dispatch();
        }
    }

    void OnApplicationQuit()
    {
        onGameCloseEvent.Dispatch();
    }

    public void OnGameOpen()
    {
        gameData.LoadGameData();
    }

    public void OnGameClose()
    {
        gameData.SaveGameData();
    }
}
