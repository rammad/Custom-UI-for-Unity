using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ui_Manager : MonoBehaviour
{
    [SerializeField] ui_Menu[] menus;
    ui_Menu currentMenu;

    public Vector2 mousePosition;

    private void Awake()
    {
        //turns on the first menu in the menus list
        if (menus.Length > 0) changeMenu(0);
    }

    //switches the currently visible menu
    //takes the position of disired menu in the menus list
    public void changeMenu(int listPos)
    {
        foreach(ui_Menu menu in menus)
        {
            if (isActiveAndEnabled) menu.gameObject.SetActive(false);
        }

        currentMenu = menus[listPos];
        currentMenu.gameObject.SetActive(true);
        setSelectedElement(currentMenu.defaultSelected);
    }

    //sets which element of the current menu is currently selected
    public void setSelectedElement(ui_Element currentElement) 
    {
        foreach(ui_Element element in currentMenu.elements)
        {
            element.selected = false;
        }

        if (currentElement != null) currentElement.selected = true;

        foreach (ui_Element element in currentMenu.elements)
        {
            element.onHover();
        }
    }

    public void switchSelectedElement(Vector2 dir)
    {
        ui_Element oldElement = null;

        foreach(ui_Element element in currentMenu.elements)
        {
            if (element.selected) oldElement = element;
        }

        if (oldElement == null) setSelectedElement(currentMenu.defaultSelected);
        else
        {
            if (dir.x > 0.6 && oldElement.neighbor_east != null) setSelectedElement(oldElement.neighbor_east);
            else if (dir.x < -0.6 && oldElement.neighbor_west != null) setSelectedElement(oldElement.neighbor_west);
            else if (dir.y > 0.6 && oldElement.neighbor_north != null) setSelectedElement(oldElement.neighbor_north);
            else if (dir.y < -0.6 && oldElement.neighbor_south != null) setSelectedElement(oldElement.neighbor_south);
        }
        
    }

    //check current cursor position against button locations and set the correct selected element
    public void hoverCheck()
    {
        ui_Element newSelectedElement = null;

        foreach (ui_Element element in currentMenu.elements)
        {
            RectTransform rect = element.GetComponent<RectTransform>();

            if (rect.position.x - (rect.rect.width/2) < mousePosition.x && mousePosition.x < rect.position.x + (rect.rect.width/2))
            {
                if (rect.position.y - (rect.rect.height/2) < mousePosition.y && mousePosition.y < rect.position.y + (rect.rect.height/2))
                {
                    newSelectedElement = element;
                }
            }
        }

        setSelectedElement(newSelectedElement);
    }

    public void pressSelectedElement()
    {
        ui_Element gettingClicked = null;

        foreach (ui_Element element in currentMenu.elements)
        {
            if (element.selected) gettingClicked = element;
        }

        if(gettingClicked != null) gettingClicked.onClick();
    }
}
