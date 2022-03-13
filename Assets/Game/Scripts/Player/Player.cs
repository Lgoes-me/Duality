using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: SerializeField]
    private Animator Animator {get; set;}

    [field: SerializeField]
    private float Speed {get; set;}

    private Vector3 WalkInput {get; set;}
    private PlayerInputActions PlayerInputActions {get; set;}

    void Start()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Enable();

        WalkInput = new Vector3(0, -1, 0);
    }

    void Update()
    {
        var playerWalkInput = PlayerInputActions.Player.Move.ReadValue<Vector2>();
        WalkInput = new Vector3(playerWalkInput.x, playerWalkInput.y, 0);
        Vector3.Normalize(WalkInput);
    }

    void FixedUpdate()
    {
        var speed = WalkInput.sqrMagnitude;
        Animator.SetFloat("Speed", speed);

        if(speed > 0)
        {
            transform.position += WalkInput * Speed * Time.deltaTime;
            Animator.SetFloat("Horizontal", WalkInput.x);
            Animator.SetFloat("Vertical", WalkInput.y);
        }
    }

    private void OnDestroy() 
    {
        PlayerInputActions.Disable();
    }
}
