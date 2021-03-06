﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StunnedBehviour : AIBehaviour, IAffectableByLaserPointer
{
    [SerializeField] private float m_stunTime;

    [SerializeField] private float m_coolDownTime;

    private bool m_canBeStunned = true;

    private bool m_isActive;

    private float m_startTime;

    private NavMeshAgent m_agent;

    private Coroutine stunTimeCoroutine;

    private AIState aiState;

    override public void Awake()
    {
        aiState = GetComponent<AIState>();
        m_agent = GetComponentInParent<NavMeshAgent>();
        GetAIController();
    }

    override public void Behaviour()
    {
        if(Time.time > m_startTime + m_stunTime)
        {
            aiState.currentState = AIState.State.Active;
            m_agent.isStopped = false;
            RemoveFromAIController();
            StartCoroutine(StunCooldown());
        }
        
    }

    override public void CheckBehaviourConditions()
    {

    }

    public void LaserEffect()
    {
        if(m_canBeStunned)
        {
            m_startTime = Time.time;
            AddToAIController();
            aiState.currentState = AIState.State.Stunned;
            m_canBeStunned = false;
            m_agent.isStopped = true;
        }
    }

    private IEnumerator StunCooldown()
    {
        yield return new WaitForSeconds(m_coolDownTime);
        m_canBeStunned = true;
    }
}
