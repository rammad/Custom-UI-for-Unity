using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Sprite), typeof(Animator))]

public class ui_Button : ui_Element
{
    public UnityEvent whenClicked;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public override void onClick()
    {
        if(selected && isActiveAndEnabled)
        {
            whenClicked.Invoke();
        }
    }

    public override void onHover()
    {
        anim.SetBool("Selected", selected);
    }
}
