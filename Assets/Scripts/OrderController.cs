using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    public Order order;
    public Guest guest;
    public Food[] foods;

    [Space(10f)]

    public Image guestImage;
    public Image[] foodImages;
    public Image buttonImage;

    void OnEnable()
    {
        order.Generate(this);
    }
}
