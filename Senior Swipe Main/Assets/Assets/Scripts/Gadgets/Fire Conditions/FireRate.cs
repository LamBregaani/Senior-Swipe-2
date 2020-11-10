using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class FireRate : MonoBehaviour, IFireCondition
    {

        [SerializeField] private float m_rate;

        public float Rate { get;  } 

        private float m_nextFireTime;

        private bool CanFire() => Time.time >= m_nextFireTime;


        public void CheckIfFireable(ref bool _fire)
        {


            if (CanFire())
            {
                m_nextFireTime = Time.time + m_rate;
            }
            else
            {
                _fire = false;
            }

        }
    }
}
