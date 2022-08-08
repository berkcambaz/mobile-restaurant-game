using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Food")]
public class Food : ScriptableObject
{
    public string title;
    public Sprite sprite;
    public Rarity rarity;
    [Range(0, 10)] public float cookTime;
    [Range(0, 10)] public float eatTime;
    public int price;
    public int stars;
}
