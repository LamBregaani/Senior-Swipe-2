using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoreHostile))]
public class DetectHostileAtRange : MonoBehaviour
{
    [SerializeField] private float range;

    [SerializeField] private Collider collider;

    [SerializeField] private LayerMask layers;

    private StoreHostile storeHostile;

    private Collider[] targets;


    private void Awake()
    {
        storeHostile = GetComponent<StoreHostile>();
    }

    private void Update()
    {
        InvokeRepeating("CheckForTarget", 0, 0.5f);
    }

    public void CheckForTarget()
    {
        targets = Physics.OverlapSphere(transform.position, range, layers);
        if (targets.Length > 0 && storeHostile.hostile == null)
        {
            storeHostile.hostile = targets[0].gameObject;
        }
        else if (targets.Length == 0 && storeHostile.hostile != null)
        {
            storeHostile.hostile = null;
        }

    }
}
