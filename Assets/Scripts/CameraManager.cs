using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private PlayerCam mainCam;
    [SerializeField] private CinemachineVirtualCamera[] cameras;

    public static CameraManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void ToggleCamera(int index)
    {
        if (index >= cameras.Length)
        {
            return;
        }

        if (cameras[index].Priority == 0)
        {
            mainCam.canMove = false;
            cameras[index].Priority += 11;
        }
        else
        {
            mainCam.canMove = true;
            cameras[index].Priority = 0;
        }
    }
}
