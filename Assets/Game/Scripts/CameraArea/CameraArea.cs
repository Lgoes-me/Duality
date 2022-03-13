using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraArea : MonoBehaviour
{
    [field: SerializeField]
    private CinemachineVirtualCamera Camera {get; set;}

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Camera.m_Priority  = 11;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Camera.m_Priority  = 8;
        }
    }

}
