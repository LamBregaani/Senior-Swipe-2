using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(StoreTarget))]
public class FireAtPlayerBehaviour : AIBehaviour
{

    private bool m_isActive;

    private StoreTarget m_storeTarget;

    private NavMeshAgent m_agent;

    private Gadget[] weapons;



    override public void Awake()
    {
        GetAIController();
        m_storeTarget = GetComponent<StoreTarget>();
        m_agent = GetComponentInParent<NavMeshAgent>();
        weapons = GetComponentsInChildren<Gadget>();
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
        foreach (var weapon in weapons)
        {
            weapon.FireGadget();
        }
    }

    override public void CheckBehaviourConditions()
    {
        if (m_storeTarget.target != null)
        {
            if (!m_isActive)
            {
                AddToAIController();
                m_agent.isStopped = false;
                m_isActive = true;
            }

        }

        else
        {
            if (m_isActive)
            {
                RemoveFromAIController();
                m_isActive = false;
            }

        }
    }

}
