using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    [SerializeField] private CinemachineBrain brain;

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
            cameras[index].Priority += 11;
        }
        else
        {
            cameras[index].Priority = 0;
        }
    }

    public void SetBlendTime(float time)
    {
        brain.m_DefaultBlend.m_Time = time;
    }
}
