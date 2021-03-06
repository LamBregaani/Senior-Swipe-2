﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDoor : MonoBehaviour
{
    private float m_laserLength;

    private bool m_isUnLocked;

    private LineRenderer[] m_lasers;




    [System.Serializable]
    public class DoorUnlockedEvent : UnityEvent { }

    public DoorUnlockedEvent onDoorUnlocked;

    public DoorUnlockedEvent onDoorLocked;

    public void Awake()
    {
        m_lasers = GetComponentsInChildren<LineRenderer>();
        m_laserLength = m_lasers[0].GetPosition(0).x;
    }


    public void Unlock()
    {
        if(!m_isUnLocked)
        {
            m_isUnLocked = true;
            onDoorUnlocked.Invoke();
            StartCoroutine(DisableLasers());
        }

    }

    public void Lock()
    {
        if (m_isUnLocked)
        {
            m_isUnLocked = false;
            onDoorLocked.Invoke();
            StartCoroutine(EnableLasers());
        }
    }

    public IEnumerator DisableLasers()
    {
        foreach (var laser in m_lasers)
        {
            float position = laser.GetPosition(0).x;

            for (float i = position; i > 0; i -= 0.14f)
            {
                Vector3 newPosition = new Vector3(i, 0, 0);
                laser.SetPosition(0, newPosition);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public IEnumerator EnableLasers()
    {
        foreach (var laser in m_lasers)
        {

            for (float i = 0; i < m_laserLength; i += 0.14f)
            {
                Vector3 newPosition = new Vector3(i, 0, 0);
                laser.SetPosition(0, newPosition);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
