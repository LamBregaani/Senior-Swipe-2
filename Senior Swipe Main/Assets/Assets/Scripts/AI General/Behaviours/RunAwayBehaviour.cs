using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAwayBehaviour : AIBehaviour
{

    [SerializeField] private float m_runAwaySpeed;

    private float m_startSpeed;

    private bool m_isActive;

    private StoreHostile m_storeHostile;

    private NavMeshAgent m_agent;

    private Vector3 destination;

    override public void Awake()
    {
        GetAIController();
        m_storeHostile = GetComponent<StoreHostile>();
        m_agent = GetComponentInParent<NavMeshAgent>();
        m_startSpeed = m_agent.speed;
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
       
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 3)
        {
            FindNewDestination();
        }

        m_agent.SetDestination(destination);

    }

    override public void CheckBehaviourConditions()
    {
        if (m_storeHostile.hostile != null)
        {
            if (!m_isActive)
            {
                FindNewDestination();
                AddToAIController();
                m_agent.isStopped = false;
                m_isActive = true;
                m_agent.speed = m_runAwaySpeed;
            }

        }

        else
        {
            if (m_isActive)
            {
                m_agent.speed = m_startSpeed;
                RemoveFromAIController();
                m_isActive = false;
            }

        }
    }

    private void FindNewDestination()
    {
        float radius = Random.Range(15, 25);
        //Vector3 randomDirection = Random.insideUnitSphere * radius;
        //randomDirection += transform.position;
        Vector3 randomDirection = transform.position - m_storeHostile.hostile.transform.position;
        randomDirection += transform.position;
        NavMeshHit hit;
        destination = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            Debug.Log("Found");
            destination = hit.position;
        }
    }


}

