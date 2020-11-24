using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerStuff : MonoBehaviour
{
    [SerializeField] private bool fireTrigger;

    [System.Serializable]
    public class TriggerEvent : UnityEvent { }

    public TriggerEvent onTrigger;

    public TriggerEvent onExitTrigger;



    public void FireTrigger(bool value)
    {
        fireTrigger = value;
    }

    public void Trigger()
    {
        if (fireTrigger)
            onTrigger?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(fireTrigger)
        onTrigger?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onExitTrigger?.Invoke();
    }
}
