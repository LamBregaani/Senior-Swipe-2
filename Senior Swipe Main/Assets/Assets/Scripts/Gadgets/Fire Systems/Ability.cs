using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour, IFireSystem
{


    private IGadgetEffect[] m_gadgetEffectScripts;

    [System.Serializable]
    public class FiredEvent : UnityEvent { }

    [SerializeField] public FiredEvent onFired;

    public delegate void FiredEffect();

    public event FiredEffect onFiredEffect;


    void Awake()
    {
        m_gadgetEffectScripts = GetComponentsInChildren<IGadgetEffect>();
    }

    private void OnEnable()
    {
        foreach (var item in m_gadgetEffectScripts)
        {
            onFiredEffect += item.GadgetEffect;
        }


    }

    private void OnDisable()
    {
        foreach (var item in m_gadgetEffectScripts)
        {
            onFiredEffect -= item.GadgetEffect;
        }
    }

    public void SetFirePoint(Transform _point)
    {
        
    }

    public void Fire()
    {
        onFired?.Invoke();
        onFiredEffect?.Invoke();
    }
}
