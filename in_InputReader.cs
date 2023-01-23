using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Works with the new Unity Input System package only!!! 
// Be sure to have the Player Input set to 'Invoke Unity Events' and create corresponding Input Actions for each function ie. MouseMove, MouseClick, Select, ect.

// Reads inputs and calls any associated functions within the UI system
// Needs to be expanded to take any other inputs, ie. your gameplay inputs

public class in_InputReader : MonoBehaviour
{
    Mouse mouse;
    ui_Manager ui;

    // Currently unused, remove unless there are issues down the road concerning switching between mouse and gamepad inputs
    // Can be used as a condition when reading mouse inputs
    [SerializeField] bool readMouse = false;

    // Finds the currently active Mouse and UI Manager
    private void Start() 
    {
        mouse = Mouse.current;
        ui = FindObjectOfType<ui_Manager>();
    }

    // Called every time the cursor's position changes, informs the UI Manager of the new position and checks for interactions with UI Elements
    public void onMouseMove(InputAction.CallbackContext ctx)
    {
        Vector3 pos = mouse.position.ReadValue();
        ui.mousePosition = new Vector2(pos.x, pos.y);
        ui.hoverCheck();
    }

    // Attempts to press whichever UI Element is currently marked as Selected
    public void onMouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ui.pressSelectedElement();
        }
    }

    // Attempts to press whichever UI Element is currently marked as Selected
    // Possibly redundant, but for now separates selection with the mouse and selection with a gamepad or keyboard
    public void onSelect(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ui.pressSelectedElement();
        }
    }

    // Switches which UI Element is currently Selected when using a gamepad or keyboard to navigate
    public void onUiMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ui.switchSelectedElement(ctx.ReadValue<Vector2>().normalized);
        }
    }
}
