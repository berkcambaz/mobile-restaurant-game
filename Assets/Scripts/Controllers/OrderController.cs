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

    void OnEnable()
    {
        order.Generate(this);
    }

    public void ButtonCook()
    {
        order.Cook(this);
    }

    public void ButtonServe()
    {
        order.Serve(this);
    }

    public void ButtonReceipt()
    {
        order.Receipt(this);
    }
}
