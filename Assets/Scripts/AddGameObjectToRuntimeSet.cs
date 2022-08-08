using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectToRuntimeSet : MonoBehaviour
{
    public GameObjectRuntimeSet runtimeSet;
    public bool addOnAwake;
    public bool removeOnOnDestroy;

    void OnEnable()
    {
        if (!addOnAwake) runtimeSet.Add(gameObject);
    }

    void OnDisable()
    {
        if (!removeOnOnDestroy) runtimeSet.Remove(gameObject);
    }

    void Awake()
    {
        if (addOnAwake) runtimeSet.Add(gameObject);
    }

    void OnDestroy()
    {
        if (removeOnOnDestroy) runtimeSet.Remove(gameObject);
    }
}
