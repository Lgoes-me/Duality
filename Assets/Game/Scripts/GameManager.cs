using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerTopDown;
    public GameObject PlayerSideScroller;

    public CinemachineVirtualCamera WorldCamera;

    public void ChangePlayer()
    {
        if(PlayerTopDown.activeInHierarchy)
        {
            PlayerSideScroller.transform.position = PlayerTopDown.transform.position;
            PlayerTopDown.SetActive(false);
            PlayerSideScroller.SetActive(true);
            WorldCamera.m_Follow = PlayerSideScroller.transform;
        }
        else
        {
            PlayerTopDown.transform.position = PlayerSideScroller.transform.position;
            PlayerSideScroller.SetActive(false);
            PlayerTopDown.SetActive(true);
            WorldCamera.m_Follow = PlayerTopDown.transform;
        }
    }
}
