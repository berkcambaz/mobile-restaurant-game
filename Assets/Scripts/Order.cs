using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Order")]
public class Order : ScriptableObject
{
    private SeedRandom srandom = new SeedRandom();

    public FoodSet foodSet;
    public GuestSet guestSet;

    public void Generate(OrderController _controller)
    {
        Guest guest = GetRandomGuest();
        Food[] foods = GetRandomFoods();

        _controller.guest = guest;
        _controller.foods = foods;

        _controller.guestImage.sprite = guest.sprite;
        for (int i = 0; i < 8; ++i)
        {
            _controller.foodImages[i].gameObject.SetActive(foods[i] != null);
            if (foods[i] != null) _controller.foodImages[i].sprite = foods[i].sprite;
        }
    }

    private Guest GetRandomGuest()
    {
        return guestSet.elements[srandom.Number(0, guestSet.elements.Length)];
    }

    private Food[] GetRandomFoods()
    {
        int count = srandom.Number(1, 8 + 1);
        Food[] foods = new Food[8];
        for (int i = 0; i < count; ++i) foods[i] = GetRandomFood();
        return foods;
    }

    private Food GetRandomFood()
    {
        return foodSet.elements[srandom.Number(0, foodSet.elements.Length)];
    }
}
