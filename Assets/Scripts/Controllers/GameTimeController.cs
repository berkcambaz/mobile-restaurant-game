using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeController : MonoBehaviour
{
    public GameTime gameTime;

    public Image gameTimeImage;

    void Update()
    {
        gameTime.UpdateTime(Time.deltaTime);
    }
}
