using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAwayWhenHitBehaviour : AIBehaviour, IAffectableByLaserPointer
{
    [SerializeField] private float m_runAwaySpeed;

    [SerializeField] private float m_runAwayTime;

    [SerializeField] private float m_coolDownTime;

    [SerializeField] private GameObject m_runAwayPoint;

    private bool m_canBeStunned = true;

    private float m_startTime;

    private float m_startSpeed;

    private bool m_isActive;

    private AIState aiState;

    private NavMeshAgent m_agent;

    private Vector3 destination;

    override public void Awake()
    {
        aiState = GetComponent<AIState>();
        GetAIController();
        m_agent = GetComponentInParent<NavMeshAgent>();
        m_startSpeed = m_agent.speed;
    }

    private void Update()
    {
        CheckBehaviourConditions();
    }

    override public void Behaviour()
    {
        if (Time.time > m_startTime + m_runAwayTime)
        {
            aiState.currentState = AIState.State.Active;
            m_agent.isStopped = false;
            RemoveFromAIController();
            StartCoroutine(RunAwayCooldown());
        }

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 3)
        {
            //FindNewDestination();
        }

        m_agent.SetDestination(destination);

    }

    override public void CheckBehaviourConditions()
    {

    }

    private void FindNewDestination()
    {
        
        //float radius = Random.Range(5, 10);
        //Vector3 randomDirection = Random.insideUnitSphere.normalized;
        //randomDirection += transform.position;
        //NavMeshHit hit;
        //destination = Vector3.zero;
        //if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        //{
        //    Debug.Log("Found");
        //    destination = hit.position;
        //}
    }

    public void LaserEffect()
    {
        if (m_canBeStunned)
        {
            destination = m_runAwayPoint.transform.position;
            m_canBeStunned = false;
            m_startTime = Time.time;
            AddToAIController();
            aiState.currentState = AIState.State.Stunned;
        }
    }

    private IEnumerator RunAwayCooldown()
    {
        yield return new WaitForSeconds(m_coolDownTime);
        m_canBeStunned = true;
    }
}
