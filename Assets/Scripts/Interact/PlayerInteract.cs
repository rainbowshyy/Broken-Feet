using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform intTransform;
    [SerializeField] private float intRadius;
    [SerializeField] private LayerMask intLayerMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    [SerializeField] private TextMeshProUGUI promptUI;

    private IInteractable interactable;

    private void Start()
    {
        InputManager.Instance.InputActions.Player.Interact.performed += Interact;
    }

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(intTransform.position, intRadius, colliders, intLayerMask);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null)
            {
                promptUI.text = interactable.IntPrompt;
            }
        }
        else
        {
            interactable = null;
            promptUI.text = "";
        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (interactable == null)
            return;

        interactable.Interact();
    }
}
