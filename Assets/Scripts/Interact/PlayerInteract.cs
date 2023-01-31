using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform intTransform;
    [SerializeField] private float intRadius;
    [SerializeField] private LayerMask intLayerMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(intTransform.position, intRadius, colliders, intLayerMask);
    }
}
