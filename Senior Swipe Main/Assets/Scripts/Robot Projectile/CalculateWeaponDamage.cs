using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CalculateWeaponDamage : MonoBehaviour, IGadgetEffectWithTarget
    {
        //The intial damage of the weapon
        private float m_startDamage;

        //The damge sent after calculating
        private float m_actualDamage;

        //Damage modifier
        private float m_modifier = 1;

        //Gets the weapon damage
        private WeaponDamage _weaponDamage;

        //Gets the scipts that dictate what this weapon can damage
        private IDamageableType[] _Damageables;

        public delegate void TargetHit(float damage, GameObject hitObject, GameObject attackerObject);

        public event TargetHit targetHit;



        private void Awake()
        {
            _Damageables = GetComponentsInChildren<IDamageableType>();
            _weaponDamage = GetComponent<WeaponDamage>();
            
        }

        private void OnEnable()
        {
            SetStats();
            foreach (var damagable in _Damageables)
            {
                targetHit += damagable.CheckObject;
            }
        }

        private void OnDisable()
        {
            foreach (var damagable in _Damageables)
            {
                targetHit -= damagable.CheckObject;
            }
        }


        void DamageModifier(float modifierAdd)
        {
            m_modifier += modifierAdd;

        }

        public void GadgetEffectWithTarget(GameObject hitObject)
        {
            
            m_actualDamage = m_startDamage * m_modifier;
            targetHit?.Invoke(m_actualDamage, hitObject, this.gameObject);
    }

        public void SetStats()
        {
            m_startDamage = _weaponDamage.ReturnWeaponDamage();
        }
    }

