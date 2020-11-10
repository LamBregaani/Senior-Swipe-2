using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StoreTarget))]
public class DetectTargetAtRange : MonoBehaviour
{
    [SerializeField] private float range;

    [SerializeField] private Collider collider;

    [SerializeField] private LayerMask layers;

    private StoreTarget storeTarget;

    private Collider[] targets;

    [System.Serializable]
    public class TargetEvent : UnityEvent { }

    [SerializeField] public TargetEvent onTargetFound;

    [SerializeField] public TargetEvent onTargetLost;


    private void Awake()
    {
        storeTarget = GetComponent<StoreTarget>();
    }

    private void Update()
    {
        InvokeRepeating("CheckForTarget", 0, 0.5f);
    }

    public void CheckForTarget()
    {
        targets = Physics.OverlapSphere(transform.position, range, layers);
        if (targets.Length > 0 && storeTarget.target == null)
        {
            storeTarget.target = targets[0].gameObject;
            onTargetFound?.Invoke();
        }
        else if (targets.Length == 0 && storeTarget.target != null)
        {
            storeTarget.target = null;
            onTargetLost?.Invoke();
        }

    }
}
