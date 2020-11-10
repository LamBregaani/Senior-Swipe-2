using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(StoreTarget))]
public class ChaseBehaviour : AIBehaviour
{

    [SerializeField] private float m_chaseSpeed;

    private bool m_isActive;

    private StoreTarget m_storeTarget;

    private NavMeshAgent m_agent;



    override public void Awake()
    {
        GetAIController();
        m_storeTarget = GetComponent<StoreTarget>();
        m_agent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {

        m_agent.SetDestination(m_storeTarget.target.transform.position);

    }

    override public void CheckBehaviourConditions()
    {
        if (m_storeTarget.target != null)
        {
            if(!m_isActive)
            {
                AddToAIController();
                m_agent.isStopped = false;
                m_isActive = true;
            }

        }
            
        else
        {
            if(m_isActive)
            {
                RemoveFromAIController();
                m_isActive = false;
            }

        }
    }

}
