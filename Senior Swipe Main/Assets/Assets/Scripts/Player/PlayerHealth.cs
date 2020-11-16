using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageableByEnemy<float>
{
    [SerializeField] private float m_maxHealth;

    [SerializeField] private float m_invincibilityDuration;

    private float m_currentHealth;

    private float m_startHealth;

    private bool m_canTakeDamage = true;

    [System.Serializable]
    public class HealthChangedEvent : UnityEvent<float, float> { }

    [SerializeField] public HealthChangedEvent onHealthChanged;

    [System.Serializable]
    public class PlayerDiedEvent : UnityEvent { }

    [SerializeField] public PlayerDiedEvent onPlayerDied;

    private void Start()
    {
        m_startHealth = m_maxHealth;
        m_currentHealth = m_maxHealth;
        onHealthChanged.Invoke(m_currentHealth, m_maxHealth);
    }


    [ContextMenu("Take Damage")]
    private void Damage()
    {
        TakeDamage(1);
    }


    public void TakeDamage(float damageTaken)
    {
        if(m_canTakeDamage)
        {
            Debug.Log("Player Hit");
            m_currentHealth -= damageTaken;
            onHealthChanged.Invoke(m_currentHealth, m_maxHealth);
            StartCoroutine(InvincibilityTime());
            if (m_currentHealth <= 0)
            {
                onPlayerDied.Invoke();
            }
        }

    }

    private IEnumerator InvincibilityTime()
    {
        m_canTakeDamage = false;
        yield return new WaitForSeconds(m_invincibilityDuration);
        m_canTakeDamage = true;
        Debug.Log("Can Take Damage");
    }
}
