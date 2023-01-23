using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class ui_Element : MonoBehaviour
{
    public bool selected;

    ui_Menu menu;

    //tolerance for what will be considered a neighbor
    //ex. 0+-navigationAngleTolerance will be considered to the east, 90+-navigationAngleTolerance will be considered to the north, ect.
    public float navigationAngleTolerance = 45f;

    public ui_Element neighbor_north = null;
    public ui_Element neighbor_south = null;
    public ui_Element neighbor_west = null;
    public ui_Element neighbor_east = null;

    //find the nearest element in each direction for navigational purposes
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

    public virtual void onClick() { }

    public virtual void onHover() { }
}
