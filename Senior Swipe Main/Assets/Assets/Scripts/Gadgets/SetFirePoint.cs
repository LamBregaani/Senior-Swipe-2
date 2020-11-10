using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFirePoint : MonoBehaviour
{

        //private GameObject m_parent;

        private IFireSystem[] m_fireSystems;

        void Awake()
        {
            var parent = this.transform.parent.gameObject;
            m_fireSystems = parent.GetComponentsInChildren<IFireSystem>();
            foreach (var fireSystem in m_fireSystems)
            {
                fireSystem.SetFirePoint(this.transform);
            }
            

        }
    
}
