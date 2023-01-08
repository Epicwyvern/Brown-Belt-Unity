using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal;
    public Transform goal2;
    Animator animator;
    NavMeshAgent agent;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        
    }

    void Update()
    {
        if (agent.hasPath) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        if (Vector3.Distance(agent.GetComponentInParent<Transform>().position, goal2.position) <= 17) {
            Destroy(GameObject.FindGameObjectWithTag("collectible"));
            agent.destination = goal2.position;
        }
    }
}
