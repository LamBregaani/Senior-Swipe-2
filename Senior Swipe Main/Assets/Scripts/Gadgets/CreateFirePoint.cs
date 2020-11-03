using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateFirePoint : MonoBehaviour
{
    [SerializeField] private GameObject m_mesh;

    private Transform m_firePoint;

    private GameObject m_firePointObj;

    private IFireSystem m_fireSystem;

    void Awake()
    {
        Vector3 _point = new Vector3(m_mesh.transform.position.x, m_mesh.transform.position.y, m_mesh.transform.position.z + (transform.lossyScale.z / 2) + 0.1f);

        m_firePointObj = Instantiate(new GameObject(), _point, Quaternion.identity);
        m_firePointObj.transform.parent = gameObject.transform;
        m_firePoint = m_firePointObj.transform;
        m_fireSystem = GetComponentInChildren<IFireSystem>();
        m_fireSystem.SetFirePoint(m_firePoint);
    }
}


