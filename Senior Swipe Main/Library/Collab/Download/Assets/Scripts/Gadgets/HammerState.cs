using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerState : MonoBehaviour
{
    public enum State { Uninflated, Inflated, Overinflated }
    public State currentState;

    [SerializeField] private float m_value;

    [SerializeField] private float m_subtractPerSecond;

    private Coroutine m_decreaseOvertimeCo;

    private PlayerJump m_playerJump;


    public GameObject modelOne;
    public GameObject modelTwo;
    public GameObject modelThree;

    private void Awake()
    {
        m_playerJump = GetComponentInParent<PlayerJump>();
        modelOne.SetActive(false);
        modelTwo.SetActive(false);
        modelThree.SetActive(false);
    }

    public void IncreaseValue()
    {
        m_value += 5;
        CheckValue();
    }

    public void DecreaseValue()
    {
        m_value -= 5;
        CheckValue();
    }

    private void CheckValue()
    {
        if (m_value <= 15 && m_value >= 0)
        {
            currentState = State.Uninflated;
            m_playerJump.JumpMulti = 1;
            m_playerJump.JumpDelay = 0;
            modelOne.SetActive(true);
            modelTwo.SetActive(false);
            modelThree.SetActive(false);
        }

        if (m_value <= 31 && m_value >= 16)
        {
            currentState = State.Inflated;
            m_playerJump.JumpMulti = 1.3f;
            //m_playerJump.JumpDelay = 0.5f;
            modelOne.SetActive(false);
            modelTwo.SetActive(true);
            modelThree.SetActive(false);
        }

        if (m_value <= 45 && m_value >= 31)
        {
            currentState = State.Overinflated;
            if(m_decreaseOvertimeCo == null)
            {
                m_decreaseOvertimeCo = StartCoroutine(DeflationOverTime());
            }
            m_playerJump.JumpMulti = 1.6f;
            //m_playerJump.JumpDelay = 0.5f;
            modelOne.SetActive(false);
            modelTwo.SetActive(false);
            modelThree.SetActive(true);
        }

        if (m_value > 45)
        {
            m_value = 45;
        }
    }

    private IEnumerator DeflationOverTime()
    {
        for (float i = m_value; i > 31; i = m_value)
        {
            m_value -= m_subtractPerSecond * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(m_value < 31)
        {
            m_decreaseOvertimeCo = null;
            CheckValue();
        }

    }
}
