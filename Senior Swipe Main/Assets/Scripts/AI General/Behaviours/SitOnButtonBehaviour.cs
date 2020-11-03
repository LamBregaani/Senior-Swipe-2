using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SitOnButtonBehaviour : AIBehaviour
{
    private Vector3 m_destination;

    private NavMeshAgent m_agent;


    override public void Awake()
    {
        m_agent = GetComponentInParent<NavMeshAgent>();
        GetAIController();
    }

    override public void Behaviour()
    {
        float distance = Vector3.Distance(transform.position, m_destination);
        if (distance <= 0.1f)
        {
            
        }
        else
        {
            m_agent.SetDestination(m_destination);
        }
    }

    override public void CheckBehaviourConditions()
    {
        
    }

    private void OnTriggerEnter(Collider _col)
    {
        var _sitPoint = _col.gameObject.GetComponent<CatSitPoint>();
        if(_sitPoint != null)
        {
            m_destination = _sitPoint.Point();
            AddToAIController();
            
        }
    }

    private void OnTriggerExit(Collider _col)
    {
        var _sitPoint = _col.gameObject.GetComponent<CatSitPoint>();
        if (_sitPoint != null)
        {
            RemoveFromAIController();
        }
    }
}
