using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(StoreTarget))]
public class PutOutFireBehaviour : AIBehaviour
{
    [SerializeField] private float m_putOutTime;

    private float m_startTime;

    private FireRug m_fire;

    private bool m_isActive;

    private NavMeshAgent m_agent;

    [System.Serializable]
    public class ExtinguishEvent : UnityEvent { }

    [SerializeField] public ExtinguishEvent onExtingushStarted;

    [SerializeField] public ExtinguishEvent onExtingushStopped;


    override public void Awake()
    {
        GetAIController();
        m_agent = GetComponentInParent<NavMeshAgent>();
        if (priority == Priority.Default)
        {
            AddToAIController();
            m_isActive = true;
        }
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
        if(Time.time >= m_startTime + m_putOutTime)
        {
            m_fire.StopFire();
            onExtingushStopped.Invoke();
            RemoveFromAIController();
            m_isActive = false;
        }

    }

    override public void CheckBehaviourConditions()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire")) 
        {
            if(!m_isActive)
            {
                onExtingushStarted?.Invoke();
                m_isActive = true;
                m_fire = other.GetComponentInParent<FireRug>();
                m_startTime = Time.time;
                AddToAIController();
            }
        }
    }
}
