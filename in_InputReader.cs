using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class in_InputReader : MonoBehaviour
{
    Mouse mouse;
    ui_Manager ui;

    [SerializeField] bool readMouse = false;

    private void Start()
    {
        mouse = Mouse.current;
        ui = FindObjectOfType<ui_Manager>();
    }

    public void onMouseMove(InputAction.CallbackContext ctx)
    {
        Vector3 pos = mouse.position.ReadValue();
        ui.mousePosition = new Vector2(pos.x, pos.y);
        ui.hoverCheck();
    }

    public void onMouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ui.pressSelectedElement();
        }
    }

    public void onSelect(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ui.pressSelectedElement();
        }
    }

    public void onUiMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ui.switchSelectedElement(ctx.ReadValue<Vector2>().normalized);
        }
    }
}
