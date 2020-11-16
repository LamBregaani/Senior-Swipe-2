using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class LaserPointer : MonoBehaviour, IFireSystem
{
    [SerializeField] private LayerMask mask;

    [SerializeField] private Transform firePoint;

    //private bool firing;

    private LineRenderer m_lineRenderer;

    private ILaserPointerEffect[] m_laserPointerEffects;

    public delegate void LaserHit(Vector3 _hitPoint);

    private event LaserHit onLaserHit;


    void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_laserPointerEffects = GetComponents<ILaserPointerEffect>();
    }

    private void OnEnable()
    {
        foreach (var _effect in m_laserPointerEffects)
        {
            onLaserHit += _effect.LaserEffect;
        }

    }

    private void OnDisable()
    {
        foreach (var _effect in m_laserPointerEffects)
        {
            onLaserHit -= _effect.LaserEffect;
        }

    }

    public void Fire()
    {
        
        m_lineRenderer.SetPosition(0, firePoint.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {
            if (hit.collider)
            {
                m_lineRenderer.SetPosition(1, hit.point);
                var target = hit.collider.GetComponentInParent<IAffectableByLaserPointer>();
                target?.LaserEffect();
                onLaserHit?.Invoke(hit.point);        
            }
        }
        else
        {
        m_lineRenderer.SetPosition(1, firePoint.transform.forward * 99999);
        }
        
    }

    public void SetFirePoint(Transform _point)
    {
        throw new System.NotImplementedException();
    }
}
