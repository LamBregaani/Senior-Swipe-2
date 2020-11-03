using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectTargetLOS : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayers;

    [SerializeField] private bool updateTargets;

    [SerializeField] private float fov;

    [SerializeField] private float rotateSpeed;

    [SerializeField] private float sightRange;

    private StoreTarget storeTarget;

    private Collider[] targets;

    [System.Serializable]
    public class TargetEvent : UnityEvent { }

    [SerializeField] public TargetEvent onTargetFound;

    [SerializeField] public TargetEvent onTargetLost;

    private void Awake()
    {
        storeTarget = GetComponentInChildren<StoreTarget>();
        if (updateTargets)
            InvokeRepeating("FindTargets", 0, 0.5f);
        else
            FindTargets();
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {

        foreach (var target in targets)
        {
            var distance = Vector3.Distance(transform.position, target.transform.position);
            if (LineOfSight(target.transform) && distance < sightRange)
            {
                RotateToTarget(target.transform);
                if(storeTarget.target == null)
                {
                    onTargetFound?.Invoke();
                    storeTarget.target = target.gameObject;
                }

                break;
                
            }
        }
        if(storeTarget.target != null)
        {
            var distance = Vector3.Distance(transform.position, storeTarget.target.transform.position);
            if (!LineOfSight(storeTarget.target.transform) && distance > sightRange)
            {
                onTargetLost?.Invoke();
                storeTarget.target = null;
            }

        }



    }

    private void RotateToTarget(Transform currentTarget)
    {
        Vector3 targetDirection = currentTarget.position - transform.position;

        float singleStep = rotateSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    bool LineOfSight(Transform target)
    {
        RaycastHit hit;
        if (Vector3.Angle(target.position - transform.position, transform.forward) <= fov &&
            Physics.Linecast(transform.position, target.position, out hit) && hit.collider.transform == target)
        {
            return true;
        }
        return false;
    }

    private void FindTargets()
    {

        targets = Physics.OverlapSphere(transform.position, 1000, targetLayers);

    }
}
