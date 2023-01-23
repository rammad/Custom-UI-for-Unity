using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

// Be sure to parent all UI Element objects to a UI Menu object!!!
// Designed for hierarchy organization and easily switching between menus
public class ui_Menu : MonoBehaviour
{
    public ui_Element[] elements;

    public ui_Element defaultSelected;

    ui_Manager manager;

    private void Awake()
    {
        elements = GetComponentsInChildren<ui_Element>();
    }
    
    private void Start()
    {
        manager = FindObjectOfType<ui_Manager>();

        if (defaultSelected == null) Debug.LogError(gameObject.name + " has no assigned default ui element");

        else manager.setSelectedElement(defaultSelected);
    }
}
