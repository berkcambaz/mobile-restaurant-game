using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    public Food food;

    public Image foodImage;
    public Text foodText;
    public RectTransform starMaskRectTransform;
    public Image goldImage;
    public Image diamondImage;
    public Text costText;

    void Start()
    {
        food.Initialize(this);
    }

    public void ButtonUpgrade()
    {
        food.Upgrade();
    }
}
