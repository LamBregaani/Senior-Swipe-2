using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator m_anim;

    private void Awake()
    {
        m_anim = GetComponentInChildren<Animator>();
    }

    public void SetAnimState(int value)
    {
        m_anim.SetInteger("Animation State", value);
        /*if (value == 0)
        {
            m_anim.Stop();
        }
        else
            m_anim.Play();*/
    }
}
