using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Order")]
public class Order : ScriptableObject
{
    private SeedRandom srandom = new SeedRandom();

    [SerializeField] private GameData gameData;
    [SerializeField] private FoodSet foodSet;
    [SerializeField] private GuestSet guestSet;

    [SerializeField] private GameEvent cookGameEvent;
    [SerializeField] private GameEvent serveGameEvent;
    [SerializeField] private GameEvent receiptGameEvent;

    public void Generate(OrderController _controller)
    {
        Guest guest = GetRandomGuest();
        Food[] foods = GetRandomFoods();

        _controller.guest = guest;
        _controller.foods = foods;

        _controller.guestImage.sprite = guest.sprite;
        for (int i = 0; i < 8; ++i)
        {
            _controller.orderFoodControllers[i].gameObject.SetActive(foods[i] != null);
            if (foods[i] != null)
                _controller.orderFoodControllers[i].foodImage.sprite = foods[i].sprite;
        }
    }

    public void Cook(OrderController _controller)
    {
        _controller.cookButton.gameObject.SetActive(false);
        _controller.serveButton.gameObject.SetActive(true);
        cookGameEvent.Dispatch();
    }

    public void Serve(OrderController _controller)
    {
        _controller.serveButton.gameObject.SetActive(false);
        _controller.receiptButton.gameObject.SetActive(true);
        serveGameEvent.Dispatch();
    }

    public void Receipt(OrderController _controller)
    {
        _controller.receiptButton.enabled = false;
        Destroy(_controller.gameObject);

        gameData.gold.value += 1;
        receiptGameEvent.Dispatch();
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
