using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericValue<T> : ScriptableObject
{
    [SerializeField] private T Value;
    [System.NonSerialized] public T value;

    void OnValidate() { value = Value; }

    void OnEnable()
    {
        value = Value;
    }
}
