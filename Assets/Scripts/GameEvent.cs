using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Dispatch()
    {
        for (int i = listeners.Count - 1; i >= 0; --i) listeners[i].OnDispatch();
    }

    public void AddListener(GameEventListener _listener)
    {
        if (!listeners.Contains(_listener)) listeners.Add(_listener);
    }

    public void RemoveListener(GameEventListener _listener)
    {
        if (listeners.Contains(_listener)) listeners.Remove(_listener);
    }
}
