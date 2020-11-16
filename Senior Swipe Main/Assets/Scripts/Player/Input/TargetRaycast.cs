using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    [SerializeField] private Camera testCamera;

    private Vector3 hitPosition;

    public Vector3 HitPosition { get => hitPosition; }

    private Camera m_cam;



    private void Awake()
    {
        ChangeCamera(testCamera);
    }

    private void LateUpdate()
    {
        //Ray ray = m_cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    hitPosition = hit.point;
        //}

        RaycastHit hit;
        if (Physics.Raycast(m_cam.transform.position, m_cam.transform.forward, out hit, Mathf.Infinity, mask))
        {
            if (hit.collider)
            {
                hitPosition = hit.point;
            }
        }
        else
            print("I'm looking at nothing!");

        Debug.DrawRay(transform.position, m_cam.transform.forward, Color.green, 100);
    }

    public void ChangeCamera(Camera _camera)
    {
        m_cam = _camera;
    }
}
