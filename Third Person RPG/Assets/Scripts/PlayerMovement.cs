using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Transform targetToFollow;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (targetToFollow != null)
        {
            agent.SetDestination(targetToFollow.position);
            faceTarget();
        }
    }

    public void moveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void followTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radiusToInteract * 0.8f;
        agent.updateRotation = false;
        targetToFollow = newTarget.interactionPoint;
    }

    public void stopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        targetToFollow = null;
    }

    void faceTarget()
    {
        Vector3 direction = (targetToFollow.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
