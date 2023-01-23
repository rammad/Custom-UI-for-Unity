using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

// The parent class for all current and future UI Elements to inheirit from
// Currently only used by UI Button but will later be used for other interactions as well ( ex. Slider, Health Bar, ect. )
public class ui_Element : MonoBehaviour
{
    public bool selected;

    ui_Menu menu;

    // Tolerance for what will be considered a neighbor
    // ex. 0+-navigationAngleTolerance will be considered to the east, 90+-navigationAngleTolerance will be considered to the north, ect.
    // Possibly redundant, all testing has shown that 45% is the most reliable solution with no dead zone
    public float navigationAngleTolerance = 45f;

    public ui_Element neighbor_north = null;
    public ui_Element neighbor_south = null;
    public ui_Element neighbor_west = null;
    public ui_Element neighbor_east = null;

    // Finds the nearest element in each direction for navigational purposes
    // Chunky solution but very reliable
    public virtual void Start()
    {
        menu = GetComponentInParent<ui_Menu>();
        if(menu != null)
        {

            foreach(ui_Element element in menu.elements)
            {

                if(element != this)
                {
                    float dist = Vector2.Distance(transform.position, element.transform.position);
                    float angle = Vector2.SignedAngle(transform.right, element.transform.position - transform.position);

                    if(angle > 0 - navigationAngleTolerance && angle < 0 + navigationAngleTolerance)
                    {
                        if(neighbor_east != null)
                        {
                            if (dist < Vector2.Distance(transform.position, neighbor_east.transform.position)) neighbor_east = element;
                        }
                        else neighbor_east = element;
                    }

                    if (angle > 90 - navigationAngleTolerance && angle < 90 + navigationAngleTolerance)
                    {
                        if (neighbor_north != null)
                        {
                            if (dist < Vector2.Distance(transform.position, neighbor_north.transform.position)) neighbor_north = element;
                        }
                        else neighbor_north = element;
                    }

                    if (angle > 180 - navigationAngleTolerance || angle < -180 + navigationAngleTolerance)
                    {
                        if (neighbor_west != null)
                        {
                            if (dist < Vector2.Distance(transform.position, neighbor_west.transform.position)) neighbor_west = element;
                        }
                        else neighbor_west = element;
                    }

                    if (angle > -90 - navigationAngleTolerance && angle < -90 + navigationAngleTolerance)
                    {
                        if (neighbor_south != null)
                        {
                            if (dist < Vector2.Distance(transform.position, neighbor_south.transform.position)) neighbor_south = element;
                        }
                        else neighbor_south = element;
                    }
                }
            }
        }
    }

    // Override to decide what occurs if this UI Element is clicked on
    public virtual void onClick() { }

    // Override to decide what occurs if this UI Element is hovered over
    public virtual void onHover() { }
}
