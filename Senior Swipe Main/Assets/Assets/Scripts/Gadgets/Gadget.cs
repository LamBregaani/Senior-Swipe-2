using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gadget : MonoBehaviour
{
    private bool m_canFire;

    private bool isFiring;

    public bool IsFiring(bool value)
    {
        isFiring = value;
        PlayEvents();
        return isFiring;
    }

    private IFireCondition[] m_fireConditions;

    private IFireSystem m_fireSystem;

    [System.Serializable]
    public class FiredEvent : UnityEvent { }

    [SerializeField] public FiredEvent onGadgetBegunFiring;

    [SerializeField] public FiredEvent onGadgetStoppedFiring;

    [SerializeField] public FiredEvent onGadgetBeingFired;

    public delegate void FireHandler();

    private event FireHandler gadgetFired;

    public delegate void CheckFireHandler(ref bool fire);

    public event CheckFireHandler checkIfGadgetIsFireable;



    private void Awake()
    {
        m_fireConditions = GetComponents<IFireCondition>();

        m_fireSystem = GetComponent<IFireSystem>();
    }

    private void OnEnable()
    {
        foreach (var _preventFire in m_fireConditions)
        {
            checkIfGadgetIsFireable += _preventFire.CheckIfFireable;
        }

        gadgetFired += m_fireSystem.Fire;

    }

    private void OnDisable()
    {
        foreach (var _preventFire in m_fireConditions)
        {
            checkIfGadgetIsFireable -= _preventFire.CheckIfFireable;
        }

        gadgetFired -= m_fireSystem.Fire;
    }

    private void Update()
    {
        if(isFiring)
        {
            FireGadget();
        }
    }

    private void PlayEvents()
    {
        if (isFiring && m_canFire)
        {
            onGadgetBegunFiring?.Invoke();
        }
        else
        {
            onGadgetStoppedFiring?.Invoke();
        }

    }

    public void FireGadget()
    {
        m_canFire = true;
        checkIfGadgetIsFireable?.Invoke(ref m_canFire);
        if (m_canFire)
        {
            onGadgetBeingFired?.Invoke();
            gadgetFired?.Invoke();
        }
    }
}

