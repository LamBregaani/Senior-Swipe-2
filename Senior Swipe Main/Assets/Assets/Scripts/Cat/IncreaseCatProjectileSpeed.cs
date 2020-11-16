using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCatProjectileSpeed : MonoBehaviour, ISlippySlimeEffect
{
    [SerializeField] private PhysicMaterial[] m_phyMats;

    [SerializeField] private Collider m_collider;

    private Coroutine m_slippySlime;



    public void SlippySpeed(float _value)
    {
        if (m_slippySlime == null)
            StopAllCoroutines();
        m_slippySlime = StartCoroutine(SlippySlimeDuration(_value));


    }

    private IEnumerator SlippySlimeDuration(float _value)
    {
        m_collider.material = m_phyMats[1];
        yield return new WaitForSeconds(0.1f);
        m_slippySlime = null;
        yield return new WaitForSeconds(0.05f);
        m_collider.material = m_phyMats[0];
    }
}
