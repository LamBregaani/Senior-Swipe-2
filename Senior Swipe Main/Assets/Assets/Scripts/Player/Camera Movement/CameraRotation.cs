using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform m_target;

    [SerializeField] private Rigidbody m_player;

    //[SerializeField] private Transform m_targetPos;

    [SerializeField] private float m_smoothingSpeed;

    private float m_mouseX;

    private float m_mouseY;

    private Player m_controls;

    private Vector2 m_inputDelta;



    private void OnEnable()
    {
        if (m_controls == null)
        {
            m_controls = new Player();
        }

        m_controls.MainControls.Enable();

        MouseLock();
    }

    private void OnDisable()
    {
        m_controls.MainControls.Disable();
    }

    void LateUpdate()
    {
        m_inputDelta = m_controls.MainControls.CameraMovement.ReadValue<Vector2>();
        CameraMovement();
    }



    public void MouseLock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MouseUnlock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void CameraMovement()
    {
        m_mouseX += m_inputDelta.x * SettingsSingleton.instance.sensitivity * Time.deltaTime;
        m_mouseY -= m_inputDelta.y * SettingsSingleton.instance.sensitivity * Time.deltaTime;
        m_mouseY = Mathf.Clamp(m_mouseY, -50, 70);

        transform.LookAt(m_target);

        m_target.rotation = Quaternion.Euler(m_mouseY, m_mouseX, 0f);

        m_player.rotation = Quaternion.Euler(0, m_mouseX, 0);

        

        /*Vector3 finalPosition = m_targetPos.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, finalPosition, m_smoothingSpeed * Time.deltaTime);
        transform.position = smoothedPosition;*/


    }
}
