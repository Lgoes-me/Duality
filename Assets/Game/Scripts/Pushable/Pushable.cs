using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public void Push(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }
}