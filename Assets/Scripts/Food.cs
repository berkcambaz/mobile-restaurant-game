using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Food")]
public class Food : ScriptableObject
{
    public string title;
    public Sprite sprite;
    public Rarity rarity;
    public int stars;
}