using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            agent.SetDestination(hit.point);
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        // Transforming velocity to local velocity.
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("forwardSpeed", speed);

    }
}
