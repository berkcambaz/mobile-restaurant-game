using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSet<T> : ScriptableObject
{
    public List<T> items = new List<T>();

    void OnEnable() { items = new List<T>(); }
    void OnDisable() { items = new List<T>(); }

    public void Add(T _item)
    {
        if (!items.Contains(_item)) items.Add(_item);
    }

    public void Remove(T _item)
    {
        if (items.Contains(_item)) items.Remove(_item);
    }
}
