using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamOnPathBehaviour : AIBehaviour
{
    [SerializeField] private Transform[] m_patrolPoints;

    private int m_currentPatrolPointIndex;

    private Transform m_nextPoint;

    private bool m_isActive;

    private NavMeshAgent m_agent;



    override public void Awake()
    {
        GetAIController();
        m_agent = GetComponentInParent<NavMeshAgent>();
        if (priority == Priority.Default)
        {
            AddToAIController();
            m_isActive = true;
        }
        m_nextPoint = m_patrolPoints[0];
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
        if (!m_agent.pathPending && m_agent.remainingDistance < 0.5f)
        {
            if (m_patrolPoints.Length > 0)
            {
                m_agent.destination = m_patrolPoints[m_currentPatrolPointIndex].position;

                m_currentPatrolPointIndex++;
                m_currentPatrolPointIndex %= m_patrolPoints.Length;
            }


        }


    }

    override public void CheckBehaviourConditions()
    {

    }
}
