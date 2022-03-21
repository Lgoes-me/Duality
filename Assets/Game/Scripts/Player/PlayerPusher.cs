using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPusher : MonoBehaviour
{
    private Pushable Pushable {get; set;}

    public bool IsPushing(Vector3 mvDirection)
    {
        var isTouching = Pushable != null;
        var otherPosition = Pushable?.transform.position ?? Vector3.zero;

        var objDirection = (otherPosition - transform.position).normalized;
        var pushing = Vector3.Dot(mvDirection, objDirection) > 0.75f; 

        if(isTouching && pushing)
        {
            Pushable.Push(mvDirection);
            return true;
        }
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Pushable"))
        {
            Pushable = other.transform.GetComponent<Pushable>();
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Pushable"))
        {
            Pushable = null;
        }
    }
}