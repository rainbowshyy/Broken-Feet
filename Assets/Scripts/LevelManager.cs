using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int levelStep;

    public static LevelManager Instance { get; private set; }

    public Action<int> OnProgress;

    private bool started = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (!started)
        {
            started = true;
            OnProgress?.Invoke(levelStep);
        }
    }

    public void Progress()
    {
        levelStep += 1;
        OnProgress?.Invoke(levelStep);
    }
}