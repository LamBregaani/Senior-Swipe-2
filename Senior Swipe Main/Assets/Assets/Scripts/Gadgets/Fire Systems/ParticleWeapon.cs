using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class ParticleWeapon : MonoBehaviour, IFireSystem
    {

        private Transform m_firePoint;

        private GameObject m_firePointObj;

        [SerializeField]private ParticleSystem[] m_particles;

        private IGadgetEffect m_weaponEffectScript;

        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent onGadgetFired;



        private void Awake()
        {
            //m_particles = GetComponentsInChildren<ParticleSystem>();
        m_weaponEffectScript = GetComponentInChildren<IGadgetEffect>();
        }


        public void SetFirePoint(Transform _point)
        {
            m_firePoint = _point;
        }

        public void Fire()
        {
            foreach (ParticleSystem _part in m_particles)
            {
                _part.Emit(20);
            }  
        
            onGadgetFired?.Invoke();
        }
    }

