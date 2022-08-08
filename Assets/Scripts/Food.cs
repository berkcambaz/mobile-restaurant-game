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
    public int upgradeCost;
    public int stars;

    public void Initialize(FoodController _controller)
    {
        _controller.foodImage.sprite = sprite;
        _controller.foodText.text = title;
        _controller.costText.text = upgradeCost.ToString();

        Vector3 scale = _controller.starMaskRectTransform.localScale;
        scale.x = 1f - (stars / 10f);
        _controller.starMaskRectTransform.localScale = scale;

        //_controller.goldImage
        //_controller.diamondImage
    }

    public void Upgrade()
    {

    }
}
