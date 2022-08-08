using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    public Order order;
    [System.NonSerialized] public Guest guest;
    [System.NonSerialized] public Food[] foods;

    [Space(10f)]

    public Image guestImage;
    public OrderFoodController[] orderFoodControllers;
    public Button cookButton;
    public Button serveButton;
    public Button receiptButton;

    void Start()
    {
        order.Generate(this);
    }

    public void ButtonCook()
    {
        StartCoroutine(order.Cook(this));
    }

    public void ButtonServe()
    {
        StartCoroutine(order.Serve(this));
    }

    public void ButtonReceipt()
    {
        StartCoroutine(order.Receipt(this));
    }
}
