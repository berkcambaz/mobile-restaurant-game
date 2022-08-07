using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public interface IStaticSet
{
    public void Fetch();
}

public abstract class StaticSet<T> : ScriptableObject, IStaticSet where T : UnityEngine.Object
{
    public T[] elements;

    public void Fetch()
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        elements = new T[guids.Length];

        for (int n = 0; n < guids.Length; n++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[n]);
            elements[n] = AssetDatabase.LoadAssetAtPath<T>(path);
        }
    }
}
