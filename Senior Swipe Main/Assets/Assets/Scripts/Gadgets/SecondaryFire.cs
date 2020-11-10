using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryFire : MonoBehaviour
{
    private Gadget m_gadget;

    public Gadget Gadget()
    {
        return m_gadget;
    }


    void Awake()
    {
        m_gadget = GetComponent<Gadget>();
    }
}
