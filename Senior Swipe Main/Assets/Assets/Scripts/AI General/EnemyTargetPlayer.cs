using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTargetPlayer : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;

    private NavMeshAgent m_agent;

    private GameObject m_targetGameObj;

    private void Awake()
    {
        m_agent = GetComponentInParent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;

    }


    private void Update()
    {
        if(m_targetGameObj)
        m_agent.SetDestination(m_targetGameObj.transform.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        var player = col.GetComponentInParent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log("player Detected");
            m_agent.isStopped = false;
            UpdateTarget(player.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        var player = col.GetComponentInParent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log("player Lost");
            m_agent.isStopped = true;
        }
    }

    private void UpdateTarget(GameObject target)
    {
        m_targetGameObj = target;
    }
    


}
