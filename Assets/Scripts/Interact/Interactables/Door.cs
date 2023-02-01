using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public string IntPrompt { get; private set; }

    private void Awake()
    {
        IntPrompt = prompt;
    }

    public bool Interact()
    {
        Debug.Log("opened door");
        return false;
    }
}
