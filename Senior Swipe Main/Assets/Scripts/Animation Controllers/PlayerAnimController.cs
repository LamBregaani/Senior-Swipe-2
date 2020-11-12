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

    }

    public void SetAnimBool(bool value)
    {
        m_anim.SetBool("In Air", value);
    }
}


