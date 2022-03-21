using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [field: SerializeField]
    private Animator Animator {get; set;}

    private Vector3 Direction {get;set;}

    public void Face(Vector3 direction)
    {
        Direction = direction;

        Animator.SetFloat("Horizontal", Direction.x);
        Animator.SetFloat("Vertical", Direction.y);
    }

    public void Walk(Vector3 direction)
    {
        float speed = direction.sqrMagnitude;
        Animator.SetFloat("Speed", speed);
        
        if(speed > 0)
        {
            Direction = direction;
        }

        Face(Direction);
    }

    public void Jump(Vector3 direction)
    {
        Animator.SetBool("IsJumping", true);
        Walk(direction);
    }

    public void Land(Vector3 direction)
    {
        Animator.SetBool("IsJumping", false);
        Walk(direction);
    }
    
    public void StartPush()
    {
        Animator.SetBool("IsPushing", true);
    }

    public void StopPush()
    {
        Animator.SetBool("IsPushing", false);
    }
}
