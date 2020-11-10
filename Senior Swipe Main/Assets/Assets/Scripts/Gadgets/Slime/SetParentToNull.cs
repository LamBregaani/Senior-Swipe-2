using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentToNull : MonoBehaviour
{
    [SerializeField] private GameObject[] m_objects;

    private void Awake()
    {

        foreach (var _obj in m_objects)
        {
            _obj.transform.parent = null;
        }
    }
}
