using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public string IntPrompt { get; private set; }

    private void Awake()
    {
        IntPrompt = prompt;
    }

    public bool Interact()
    {
        LevelManager.Instance.Progress();
        gameObject.SetActive(false);
        return true;
    }
}