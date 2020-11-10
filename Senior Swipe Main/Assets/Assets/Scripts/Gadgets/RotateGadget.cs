using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGadget : MonoBehaviour
{

    [SerializeField] private GameObject m_mesh;

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
    }

    private void OnDisable()
    {
        m_controls.MainControls.Disable();
    }

    void LateUpdate()
    {
        m_inputDelta = m_controls.MainControls.CameraMovement.ReadValue<Vector2>();
        GadgetMovement();
    }

    private void GadgetMovement()
    {
        m_mouseX += m_inputDelta.x * SettingsSingleton.instance.sensitivity * Time.deltaTime;
        m_mouseY -= m_inputDelta.y * SettingsSingleton.instance.sensitivity * Time.deltaTime;
        m_mouseY = Mathf.Clamp(m_mouseY, -50, 70);

        m_mesh.transform.rotation = Quaternion.Euler(m_mouseY, m_mouseX, m_mesh.transform.rotation.z);



    }

}
