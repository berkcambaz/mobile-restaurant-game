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
    public Image[] foodImages;

    void OnEnable()
    {
        order.Generate(this);
    }
}
