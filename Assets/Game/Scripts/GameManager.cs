using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    protected static readonly int shGradRange = Shader.PropertyToID("_GradientRange");    
    public static GameManager Instance;

    private void Awake() 
    {
        Instance = this;
    }

    public Material material;

    public GameObject PlayerTopDown;
    public GameObject PlayerSideScroller;

    public CinemachineVirtualCamera WorldCamera;

    public void ChangePlayer()
    {
        if(PlayerTopDown.activeInHierarchy)
        {
            material.SetFloat(shGradRange, 1);
            PlayerSideScroller.transform.position = PlayerTopDown.transform.position;
            PlayerTopDown.SetActive(false);
            PlayerSideScroller.SetActive(true);
            WorldCamera.m_Follow = PlayerSideScroller.transform;
        }
        else
        {
            material.SetFloat(shGradRange, 0);
            PlayerTopDown.transform.position = PlayerSideScroller.transform.position;
            PlayerSideScroller.SetActive(false);
            PlayerTopDown.SetActive(true);
            WorldCamera.m_Follow = PlayerTopDown.transform;
        }
    }
}
