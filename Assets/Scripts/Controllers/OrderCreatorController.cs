using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCreatorController : MonoBehaviour
{
    public GameData gameData;

    public GameObject orderPrefab;
    public GameObject orderContainer;

    public void CreateRandomOrder()
    {
        Instantiate(orderPrefab, Vector3.zero, Quaternion.identity, orderContainer.transform);
    }
}
