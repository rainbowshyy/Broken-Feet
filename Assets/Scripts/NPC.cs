using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Animator animator;
    public Vector3 walkTowards;
    public bool walking;
    public Vector3 sitDir;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = walkTowards;
        animator.SetBool("move", agent.velocity.magnitude > 0.05f);
        if (animator.GetBool("sit") && !animator.GetBool("move"))
        {
            transform.position = walkTowards;
            transform.forward = sitDir;
        }
    }

    public void Sit(bool toggle)
    {
        animator.SetBool("sit", toggle);
    }

    public void MoveTo(Vector3 pos)
    {
        animator.SetBool("move", true);
        walkTowards = pos;
    }

    public void LookTowards(Vector3 point)
    {
        transform.forward = (point - transform.position).normalized;
    }

    public void LookDirection(Vector3 dir)
    {
        transform.forward = dir;
    }
}
