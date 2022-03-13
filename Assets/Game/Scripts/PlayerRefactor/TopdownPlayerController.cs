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

    void Start()
    {
        PlayerAnimationController.Face(Vector3.down);
    }

    private void Update()
    {
        var direction = InputManager.WalkInput;

        Attack(direction);
    }

    private void FixedUpdate()
    {
        var direction = InputManager.WalkInput;

        Walk(direction);
    }

    private void Attack(Vector3 direction)
    {
        if(InputManager.AttackDown)
        {
            PlayerAnimationController.Attack(direction);
        }
    }

    private void Walk(Vector3 direction)
    {
        var input = direction.sqrMagnitude;

        PlayerAnimationController.Walk(direction);

        if(input > 0)
        {
            transform.position += direction * Speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var direction = InputManager.WalkInput;

        if(other.gameObject.CompareTag("Pushable"))
        {
            PlayerAnimationController.StartPush(direction);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        var direction = InputManager.WalkInput;

        if(other.gameObject.CompareTag("Pushable"))
        {
            PlayerAnimationController.StopPush(direction);
        }
    }
}
