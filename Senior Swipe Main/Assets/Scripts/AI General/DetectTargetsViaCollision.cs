using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectTargetsViaCollision : MonoBehaviour
{

    private AIState m_state;

    private StoreTarget storeTarget;

    private Collider[] targets;

    [System.Serializable]
    public class TargetEvent : UnityEvent { }

    [SerializeField] public TargetEvent onTargetFound;

    [SerializeField] public TargetEvent onTargetLost;

    private void Awake()
    {
        m_state = GetComponentInChildren<AIState>();
        storeTarget = GetComponentInChildren<StoreTarget>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided");
        storeTarget.target = collision.gameObject;
        onTargetFound?.Invoke();
    }

    private void OnTriggerExit(Collider collision)
    {
        storeTarget.target = null;
        onTargetLost?.Invoke();
    }
}
