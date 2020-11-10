using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGadget : MonoBehaviour
{
    private Gadget m_pF;

    public Gadget PF => m_pF;

    private Gadget m_sF;

    public Gadget SF => m_sF;



    private void Start()
    {
        var _primaryFire = GetComponentInChildren<PrimaryFire>();
        m_pF = _primaryFire.Gadget();

        //var _secondaryFire = GetComponentInChildren<SecondaryFire>();

        //m_sF = _secondaryFire.Gadget();
    }
}
