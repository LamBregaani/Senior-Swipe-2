using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireSpecialGadget : MonoBehaviour
{
    private bool m_firing;

    [SerializeField]private bool toggleFire = true;

    private Gadget m_currentGadget;

    

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        var _gadget = GetComponentInChildren<SpecialGadget>();
        UpdateGadget(_gadget);

    }

    public void Firing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(!toggleFire)
            {
                m_firing = true;
                m_currentGadget.IsFiring(m_firing);
            }
            else
            {
                m_firing = !m_firing;
                m_currentGadget.IsFiring(m_firing);
            }


        }
        else if (context.canceled)
        {
            if(!toggleFire)
            {
                m_firing = false;
                m_currentGadget.IsFiring(m_firing);
            }

        }
    }

    public void UpdateGadget(SpecialGadget _gadget)
    {
        m_currentGadget = _gadget.PF;
        if (m_currentGadget == null)
            print("No weapon equiped!");
    }

    public void Firing()
    {
        
    }
}
