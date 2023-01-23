using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Adds a Rammad UI submenu to the GameObject menu to quickly add UI objects to the heirarchy
// Currently only contains a Button and a Menu but can be expanded
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
