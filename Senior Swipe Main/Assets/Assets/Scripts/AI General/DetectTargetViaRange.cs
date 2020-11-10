using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectTargetViaRange : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayers;

    [SerializeField] private bool updateTargets;

    [SerializeField] private float range;

    [SerializeField] private float rotateSpeed;

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
        if(targets.Length > 0)
        {
            foreach (var target in targets)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < range)
                {
                    RotateToTarget(target.transform);
                    onTargetFound?.Invoke();
                    storeTarget.target = target.gameObject;
                    break;
                }
            }
        }
        else
        {
            storeTarget.target = null;
        }

        

        
    }

    private void RotateToTarget(Transform currentTarget)
    {
        Vector3 targetDirection = currentTarget.position - transform.position;

        float singleStep = rotateSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    //bool LineOfSight(Transform target)
    //{

    //    RaycastHit hit;
    //    if (Vector3.Angle(target.position - transform.position, transform.forward) <= fov &&
    //        Physics.Linecast(transform.position, target.position, out hit) && hit.collider.transform == target)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    private void FindTargets()
    {
        //if(storeTarget.target = null)
        //{
        
            targets = Physics.OverlapSphere(transform.position, 1000, targetLayers);
        //}

    }
}
