using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    private bool m_isPressed;

    [System.Serializable]
    public class ButtonPressEvent : UnityEvent{ }

    public ButtonPressEvent onButtonPressed;

    public ButtonPressEvent onButtonUnpressed;


    private void OnTriggerEnter(Collider other)
    {
        if(!m_isPressed)
        {
            m_isPressed = true;
            onButtonPressed.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (m_isPressed)
        {
            m_isPressed = false;
            onButtonUnpressed.Invoke();
        }
    }
}
