using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenericSignallable<T> : ScriptableObject
{
    private List<Callback> listeners = new List<Callback>();
    public delegate void Callback(T _value);

    [SerializeField] private T Value;

    private T _value;
    public T value
    {
        get { return _value; }
        set
        {
            _value = value;
            Notify();
        }
    }

    void OnValidate() { value = Value; }

    void OnEnable()
    {
        _value = Value;
    }

    private void Notify()
    {
        for (int i = listeners.Count - 1; i >= 0; --i) listeners[i](_value);
    }

    public void AddListener(Callback _callback)
    {
        if (!listeners.Contains(_callback)) listeners.Add(_callback);
    }

    public void RemoveListener(Callback _callback)
    {
        if (listeners.Contains(_callback)) listeners.Remove(_callback);
    }
}
