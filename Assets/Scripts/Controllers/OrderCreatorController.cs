using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCreatorController : MonoBehaviour
{
    public Order order;

    public GameObject orderPrefab;
    public GameObject orderContainer;

    public void CreateOrder()
    {
        order.Create(this);
    }
}
