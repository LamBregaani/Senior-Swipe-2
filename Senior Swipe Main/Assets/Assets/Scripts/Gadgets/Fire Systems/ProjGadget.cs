using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjGadget : MonoBehaviour, IFireSystem
{
    [SerializeField] private GameObject m_projectile;

    [SerializeField]private Transform m_firePoint;

    private IGadgetEffect[] m_gadgetEffectScripts;



    [System.Serializable]
    public class FiredEvent : UnityEvent { }

    [SerializeField] public FiredEvent onGadgetFired;

    public delegate void FiredEffect();

    public event FiredEffect onFiredEffect;



    void Awake()
    {
        m_gadgetEffectScripts = GetComponentsInChildren<IGadgetEffect>();
    }

    private void OnEnable()
    {
        foreach (var _item in m_gadgetEffectScripts)
        {
            onFiredEffect += _item.GadgetEffect;
        }


    }

    private void OnDisable()
    {
        foreach (var _item in m_gadgetEffectScripts)
        {
            onFiredEffect -= _item.GadgetEffect;
        }
    }




    public void SetFirePoint(Transform _point)
    {
        m_firePoint = _point;
    }

    public void Fire()
    {

        

        var _proj = Instantiate(m_projectile, m_firePoint.position, m_firePoint.rotation);

        onFiredEffect?.Invoke();
    }
}


