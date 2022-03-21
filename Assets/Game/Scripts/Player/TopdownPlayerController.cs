using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownPlayerController : MonoBehaviour
{
    [field: SerializeField]
    private float Speed {get; set;}

    [field: SerializeField]
    private InputManager InputManager {get; set;}

    [field: SerializeField]
    private PlayerAnimationController PlayerAnimationController {get; set;}

    [field: SerializeField]
    private PlayerPusher PlayerPusher {get; set;}

    void Start()
    {
        PlayerAnimationController.Face(Vector3.down);
    }

    private void FixedUpdate()
    {
        var direction = InputManager.WalkInput;

        Walk(direction);
    }

    private void Walk(Vector3 direction)
    {
        var input = direction.sqrMagnitude;

        if(PlayerPusher.IsPushing(direction))
            PlayerAnimationController.StartPush();
        else
            PlayerAnimationController.StopPush();
        
        PlayerAnimationController.Walk(direction);

        if(input > 0)
        {
            transform.position += direction * Speed * Time.deltaTime;
        }
    }
}
