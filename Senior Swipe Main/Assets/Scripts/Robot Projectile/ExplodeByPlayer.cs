using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeByPlayer : MonoBehaviour
{
    private Gadget m_gadget;



    private void Awake()
    {
        m_gadget = GetComponent<Gadget>();
    }

    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<IDamageableByEnemy<float>>();
        if (enemy != null)
        {

            m_gadget.FireGadget();
            

        }

    }
}
