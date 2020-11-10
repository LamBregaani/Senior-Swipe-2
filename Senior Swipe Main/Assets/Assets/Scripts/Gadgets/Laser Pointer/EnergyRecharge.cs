using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyRecharge : MonoBehaviour
{
    //Length of time for the energy to fully recharge
    [SerializeField] private float m_coolDownTime;

    //Length of time before the cool down automatically starts when the player isn't firing
    [SerializeField] private float m_coolDownDelay;

    [System.Serializable]
    public class CoolDownCompleteEvent : UnityEvent { }

    [SerializeField] public CoolDownCompleteEvent onCoolDownComplete;

    [System.Serializable]
    public class CoolDownStartedEvent : UnityEvent<float> { }

    [SerializeField] public CoolDownStartedEvent onCoolDownStarted;

    public void StartCoolDown()
    {
        onCoolDownStarted?.Invoke(m_coolDownTime);
        StartCoroutine(CoolDown());
    }

    public void StartCoolDownDelay()
    {
        StartCoroutine(CoolDownDelay());
    }

    public void StopCoolDown()
    {
        StopAllCoroutines();
    }

    private IEnumerator CoolDownDelay()
    {
        yield return new WaitForSeconds(m_coolDownDelay);
        StartCoolDown();
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(m_coolDownTime);
        onCoolDownComplete?.Invoke();
    }
}
