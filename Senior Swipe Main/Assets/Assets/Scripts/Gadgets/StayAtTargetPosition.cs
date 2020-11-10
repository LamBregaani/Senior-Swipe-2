using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAtTargetPosition : MonoBehaviour
{
    [SerializeField] private Transform m_targetPosition;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = m_targetPosition.position;

        transform.rotation = m_targetPosition.rotation;
    }
}
