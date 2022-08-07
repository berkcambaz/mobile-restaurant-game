using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public IntSignallable gold;
    public IntSignallable diamond;
    public GameTime gameTime;
}
