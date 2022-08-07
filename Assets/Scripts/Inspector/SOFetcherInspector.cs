using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StaticSet<>), true)]
public class SOFetcherInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IStaticSet staticSet = (IStaticSet)target;
        if (GUILayout.Button("Fetch")) staticSet.Fetch();
    }
}
