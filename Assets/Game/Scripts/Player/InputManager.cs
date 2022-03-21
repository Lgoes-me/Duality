using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    public bool JumpDown {get; private set;}
    public bool JumpUp {get; private set;}

    public bool InteractDown {get; private set;}
    public Vector3 WalkInput {get; private set;}

    private PlayerInputActions PlayerInputActions {get; set;}

    private void Start() 
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Enable();
    }

    private void Update()
    {
        WalkInput = PlayerInputActions.Player.Move.ReadValue<Vector2>();
        Vector3.Normalize(WalkInput);
        
        var jumpButton = (ButtonControl)PlayerInputActions.FindAction("Jump").controls[0];
        JumpDown = jumpButton.wasPressedThisFrame;
        JumpUp = jumpButton.wasReleasedThisFrame;

        var interactButton = (ButtonControl)PlayerInputActions.FindAction("Interact").controls[0];
        InteractDown = interactButton.wasPressedThisFrame;
    }

    private void OnDestroy() 
    {
        PlayerInputActions.Disable();
    }
}
