using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreatorController : MonoBehaviour
{
    public FoodCollection foodCollection;

    public GameObject foodPrefab;
    public GameObject foodContainer;

    void Start()
    {
        for (int i = 0; i < foodCollection.foods.Length; ++i)
        {
            GameObject foodGameObject = Instantiate(foodPrefab, Vector3.zero, Quaternion.identity, foodContainer.transform);
            foodGameObject.GetComponent<FoodController>().food = foodCollection.foods[i];
        }
    }
}
