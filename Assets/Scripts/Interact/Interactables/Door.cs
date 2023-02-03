using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject collision;

    [SerializeField] private LayerMask intLayerMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    public string IntPrompt { get; private set; }
    private bool open;

    private void Awake()
    {
        IntPrompt = prompt;
        open = false;
    }

    private void Update()
    {
        if (open)
        {
            return;
        }

        numFound = Physics.OverlapSphereNonAlloc(transform.position, 2f, colliders, intLayerMask);

        if (numFound > 0)
        {
            Toggle();
        }
    }

    public bool Interact()
    {
        Toggle();
        return false;
    }

    public void Toggle()
    {
        animator.SetBool("Open", !open);
        collision.SetActive(open);
        open = !open;
        if (open)
        {
            IntPrompt = "Trykk på museknappen for å lukke døren.";
        }
        else
        {
            IntPrompt = "Trykk på museknappen for å åpne døren.";
        }
    }
}
