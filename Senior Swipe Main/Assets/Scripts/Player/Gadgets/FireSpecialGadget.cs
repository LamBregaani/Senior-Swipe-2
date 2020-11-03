using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireSpecialGadget : MonoBehaviour
{
    private bool m_firing;

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
            m_firing = true;
            m_currentGadget.IsFiring(m_firing);

        }
        else if (context.canceled)
        {
            m_firing = false;
            m_currentGadget.IsFiring(m_firing);
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
