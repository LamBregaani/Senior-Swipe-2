using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RoamBehaviour : AIBehaviour
{

    private bool m_isActive;

    private bool waiting = true;

    private NavMeshAgent m_agent;

    private Vector3 destination;

    override public void Awake()
    {
        GetAIController();
        m_agent = GetComponentInParent<NavMeshAgent>();
        if (priority == Priority.Default)
        {
            AddToAIController();
            m_isActive = true;
        }
        destination = this.transform.position;
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 2.5)
            if(waiting)
            {
                waiting = false;
                StartCoroutine(WaitTime());
            }
      
            m_agent.SetDestination(destination);
    }

    private void FindNewDestination()
    {
        float radius = Random.Range(15, 25);
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        destination = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            destination = hit.position;
        }
        
    }

    private IEnumerator WaitTime()
    {
        float duration = Random.Range(3, 8);
        yield return new WaitForSeconds(duration);
        waiting = true;
        FindNewDestination();
    }

    override public void CheckBehaviourConditions()
    {
        
    }
}
