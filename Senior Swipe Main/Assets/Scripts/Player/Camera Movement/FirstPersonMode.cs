using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMode : MonoBehaviour
{
    [SerializeField] private GameObject m_firstPersonCamera, m_thirdPErsonCamera;

    private bool m_currentView;
    


    public void ChangeView()
    {
        m_currentView = !m_currentView;

        m_firstPersonCamera.SetActive(m_currentView);
        m_thirdPErsonCamera.SetActive(!m_currentView);
    }
}
