using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]private Transform m_playerPosition;
    [SerializeField]private Vector3 m_offSet;
    [SerializeField]private float m_smoothingSpeed;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 _finalPosition = m_playerPosition.position + m_offSet;
        Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _finalPosition, m_smoothingSpeed * Time.deltaTime);
        transform.position = _smoothedPosition;
    }
}
