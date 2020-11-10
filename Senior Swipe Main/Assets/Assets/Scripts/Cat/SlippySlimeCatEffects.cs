using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlippySlimeCatEffects : MonoBehaviour, ISlippySlimeEffect
{
    private float m_startSpeed;

    private NavMeshAgent m_agent;

    private Coroutine m_slippySlime;


    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_startSpeed = m_agent.speed;
    }

    public void SlippySpeed(float _value)
    {
        if (m_slippySlime == null)
            StopAllCoroutines();
        m_slippySlime = StartCoroutine(SlippySlimeDuration(_value));
    }

    private IEnumerator SlippySlimeDuration(float _value)
    {
        
        m_agent.speed = m_startSpeed * _value;
        yield return new WaitForSeconds(0.1f);
        m_slippySlime = null;
        yield return new WaitForSeconds(0.05f);
        m_agent.speed = m_startSpeed;
    }
}
