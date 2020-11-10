using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandGuardBehaviour : AIBehaviour
{

    [SerializeField] private Transform m_GuardTransform;

    private Vector3 m_guardPoint;

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
        if (m_GuardTransform == null)
            m_guardPoint = this.transform.position;
        else
            m_guardPoint = m_GuardTransform.position;
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
        float distance = Vector3.Distance(transform.position, m_guardPoint);
        if (distance >= 2.5)
        {
            m_agent.SetDestination(m_guardPoint);
        }

        
    }

    override public void CheckBehaviourConditions()
    {

    }
}
