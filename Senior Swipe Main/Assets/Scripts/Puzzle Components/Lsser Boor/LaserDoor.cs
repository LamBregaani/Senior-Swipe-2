using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDoor : MonoBehaviour
{
    [SerializeField] private int buttonsToUnlock;

    [SerializeField] private bool autoRelock;

    private int currentButtons;

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
        currentButtons++;

        if(!m_isUnLocked && currentButtons >= buttonsToUnlock)
        {
            m_isUnLocked = true;
            onDoorUnlocked.Invoke();
            StartCoroutine(DisableLasers());
        }

    }

    public void Lock()
    {
        currentButtons--;

        if (m_isUnLocked && currentButtons < buttonsToUnlock && autoRelock)
        {
            m_isUnLocked = false;
            onDoorLocked.Invoke();
            StartCoroutine(EnableLasers());
        }
    }

    public IEnumerator DisableLasers()
    {
        Vector3 newPosition;
        foreach (var laser in m_lasers)
        {
            float position = laser.GetPosition(0).x;

            for (float i = position; i > 0; i -= Time.deltaTime * 40)
            {
                newPosition = new Vector3(i, 0, 0);
                laser.SetPosition(0, newPosition);
                yield return new WaitForEndOfFrame();
            }
            newPosition = new Vector3(0, 0, 0);
            laser.SetPosition(0, newPosition);
        }
    }

    public IEnumerator EnableLasers()
    {
        Vector3 newPosition;
        foreach (var laser in m_lasers)
        {
            
            for (float i = 0; i < m_laserLength; i += Time.deltaTime * 50)
            {
                newPosition = new Vector3(i, 0, 0);
                laser.SetPosition(0, newPosition);
                yield return new WaitForEndOfFrame();
            }
            newPosition = new Vector3(m_laserLength, 0, 0);
            laser.SetPosition(0, newPosition);
        }
    }
}
