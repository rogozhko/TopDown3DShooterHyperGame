using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class GUIText : MonoBehaviour
{

    public string textForDebug = "";
    [Range(20, 60)] public int fontSize;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 500, Screen.width, fontSize * 10), textForDebug);
        GUI.skin.label.fontSize = fontSize;
    }

}