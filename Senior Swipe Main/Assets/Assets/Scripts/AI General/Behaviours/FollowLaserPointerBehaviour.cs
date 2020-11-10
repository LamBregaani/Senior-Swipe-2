using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowLaserPointerBehaviour : AIBehaviour
{

    private bool m_isActive;

    private NavMeshAgent m_agent;

    private Vector3 m_destination;

    private bool hasDestination;

    private bool isFiring;



    override public void Awake()
    {
        GetAIController();
        m_agent = GetComponentInParent<NavMeshAgent>();
    }

    public void OnEnable()
    {
        SendLaserPointerLocation.OnLaserHit += SetDestination;
        SendLaserPointerLocation.OnPlayerFiring += IsPlayerFiring;
    }

    public void OnDisable()
    {
        SendLaserPointerLocation.OnLaserHit -= SetDestination;
        SendLaserPointerLocation.OnPlayerFiring -= IsPlayerFiring;
    }

    override public void Behaviour()
    {
        m_agent.SetDestination(m_destination);
    }

    override public void CheckBehaviourConditions()
    {
        if(hasDestination && isFiring)
        {
            if(!m_isActive)
            {
                AddToAIController();
                m_isActive = true;
            }
                
        }
        else
        {
            m_isActive = false;
            RemoveFromAIController();
        }
    }

    private void SetDestination(Vector3 _value)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(_value, out hit, 10, 1))
        {
            m_destination = hit.position;
            hasDestination = true;
        }
        else
        {
            hasDestination = false;
        }
        CheckBehaviourConditions();
    }

    public void IsPlayerFiring(bool _value)
    {
        isFiring = _value;
        CheckBehaviourConditions();
    }
}
