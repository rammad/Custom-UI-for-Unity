using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ui_Editor : ScriptableObject
{
    [MenuItem("GameObject/RammadUI/Button")]
    public static void createButton()
    {
        GameObject obj = new GameObject();
        obj.AddComponent(typeof(ui_Button));
        obj.name = "Button";
    }

    [MenuItem("GameObject/RammadUI/Menu")]
    public static void createMenu()
    {
        GameObject obj = new GameObject();
        obj.AddComponent(typeof(ui_Menu));
        obj.name = "Menu";
    }
}
