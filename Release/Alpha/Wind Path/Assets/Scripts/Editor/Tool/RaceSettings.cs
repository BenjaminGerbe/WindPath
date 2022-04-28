using System;
using UnityEditor;
using UnityEngine;


public class RaceSettings : EditorWindow
{
    [MenuItem("Racing/Configure Racing")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(RaceSettings));
    }
    

    private void OnGUI()
    {
        GUILayout.Label("Set racing parameters",EditorStyles.whiteLargeLabel);
        
    }
}
