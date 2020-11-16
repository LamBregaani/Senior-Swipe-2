using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSLaser : MonoBehaviour
{
    [SerializeField] private Transform m_firePoint;

    private LineRenderer m_lineRenderer;


    void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        m_lineRenderer.SetPosition(0, m_firePoint.position);
        RaycastHit hit;
        if (Physics.Raycast(m_firePoint.position, transform.up, out hit, Mathf.Infinity))
        {
            if (hit.collider)
            {
                m_lineRenderer.SetPosition(1, hit.point);
                var target = hit.collider.GetComponentInParent<IAffectableByLaserPointer>();
                target?.LaserEffect();
                //onLaserHit?.Invoke(hit.point);
            }
        }
        else
        {
            m_lineRenderer.SetPosition(1, m_firePoint.up * 99999);
        }
    }
}
