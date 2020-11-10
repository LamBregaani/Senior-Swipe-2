using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private float m_startDamage;

        [SerializeField]private float m_weaponDamage;

        public float ReturnWeaponDamage()
        {
            return m_weaponDamage;
        }

        public void SetWeaponDamge(float newDamage)
        {
            m_weaponDamage = newDamage;
        }

        public void MultiplyWeaponDamage(float multi)
        {
            m_weaponDamage *= multi;
        }

        public void ResetDamage()
        {
            m_weaponDamage = m_startDamage;
        }
    }

