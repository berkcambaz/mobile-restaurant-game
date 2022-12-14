using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Order")]
public class Order : ScriptableObject
{
    private SeedRandom srandom = new SeedRandom();

    [SerializeField] private GameData gameData;
    [SerializeField] private FoodCollection foodCollection;
    [SerializeField] private GuestCollection guestCollection;
    [SerializeField] private GameObjectRuntimeSet orderGameObjects;

    [SerializeField] private GameEvent cookGameEvent;
    [SerializeField] private GameEvent serveGameEvent;
    [SerializeField] private GameEvent receiptGameEvent;

    public void Create(OrderCreatorController _controller)
    {
        if (orderGameObjects.items.Count >= gameData.maxOrderCount.value) return;

        GameObject prefab = _controller.orderPrefab;
        Transform parent = _controller.orderContainer.transform;
        Instantiate(prefab, Vector3.zero, Quaternion.identity, parent);
    }

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

    public IEnumerator Cook(OrderController _controller)
    {
        _controller.cookButton.interactable = false;

        for (int i = 0; i < _controller.foods.Length; ++i)
        {
            if (_controller.foods[i] == null) break;

            float cookTime = _controller.foods[i].cookTime;
            OrderFoodController foodController = _controller.orderFoodControllers[i];

            yield return _controller.StartCoroutine(foodController.Progress(cookTime));
        }

        cookGameEvent.Dispatch();
        _controller.cookButton.gameObject.SetActive(false);
        _controller.serveButton.gameObject.SetActive(true);
    }

    public IEnumerator Serve(OrderController _controller)
    {
        _controller.serveButton.interactable = false;

        for (int i = 0; i < _controller.foods.Length; ++i)
        {
            if (_controller.foods[i] == null) break;

            float eatTime = _controller.foods[i].eatTime;
            OrderFoodController foodController = _controller.orderFoodControllers[i];

            yield return _controller.StartCoroutine(foodController.Progress(eatTime));
        }

        serveGameEvent.Dispatch();
        _controller.serveButton.gameObject.SetActive(false);
        _controller.receiptButton.gameObject.SetActive(true);

        yield return null;
    }

    public IEnumerator Receipt(OrderController _controller)
    {
        _controller.receiptButton.interactable = false;

        int totalPrice = 0;
        for (int i = 0; i < _controller.foods.Length; ++i)
        {
            if (_controller.foods[i] == null) break;

            totalPrice += _controller.foods[i].price;
        }
        gameData.gold.value += totalPrice;

        receiptGameEvent.Dispatch();
        Destroy(_controller.gameObject);

        yield return null;
    }

    private Guest GetRandomGuest()
    {
        return guestCollection.guests[srandom.Number(0, guestCollection.guests.Length)];
    }

    private Food[] GetRandomFoods()
    {
        Food[] output = new Food[8];

        int count = srandom.Number(1, 8 + 1);
        Food[] foods = new Food[count];
        for (int i = 0; i < count; ++i) foods[i] = GetRandomFood();

        Array.Sort(foods, (x, y) => x.GetHashCode().CompareTo(y.GetHashCode()));
        Array.Copy(foods, output, count);

        return output;
    }

    private Food GetRandomFood()
    {
        return foodCollection.foods[srandom.Number(0, foodCollection.foods.Length)];
    }
}
