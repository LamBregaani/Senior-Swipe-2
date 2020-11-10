using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHostileViaRange : MonoBehaviour
{
    [SerializeField] private LayerMask m_hostileLayers;

    [SerializeField] private bool m_updateHostiles;

    [SerializeField] private float m_range;

    private StoreHostile m_storeHostile;

    private Collider[] m_hostiles;

    private void Awake()
    {
        m_storeHostile = GetComponentInChildren<StoreHostile>();
        if (m_updateHostiles)
            InvokeRepeating("FindHostiles", 0, 0.5f);
        else
            FindHostiles();
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {

        foreach (var target in m_hostiles)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < m_range && target.transform.root.GetComponentInChildren<AIState>()?.currentState != AIState.State.Stunned)
            {
                m_storeHostile.hostile = target.gameObject;
                break;
            }
            else
            {
                m_storeHostile.hostile = null;
            }
        }




    }

    private void FindHostiles()
    { 
        m_hostiles = Physics.OverlapSphere(transform.position, 1000, m_hostileLayers);

    }
}
