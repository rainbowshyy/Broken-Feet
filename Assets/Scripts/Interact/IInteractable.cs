using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string IntPrompt { get; }

    public bool Interact();
}
