using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    private TargetRaycast m_targetRaycast;



    void Awake()
    {
        m_targetRaycast = GetComponentInParent<TargetRaycast>();
    }

    private void Update()
    {
        this.transform.LookAt(m_targetRaycast.HitPosition);
    }
}
