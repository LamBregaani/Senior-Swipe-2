using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    public class ReserveOnlyClipType : MonoBehaviour, IFireCondition, IWeaponClipType
    {
    [SerializeField]private float m_reserveAmmoMax;

    [SerializeField] private float soundDelay;

    private float timeStamp;

    private float m_reserveAmount;

    private bool m_noAmmo;

    [System.Serializable]
    public class NoAmmoEvent : UnityEvent { }

    [SerializeField] public NoAmmoEvent onNoAmmo;

    [SerializeField] public NoAmmoEvent onFiringWithNoAmmo;

    public float MaxAmmo()
    {
        return m_reserveAmmoMax;
    }

    public float CurrentAmmo()
    {
        return m_reserveAmount;
    }

    void Start()
        {
            m_reserveAmount = m_reserveAmmoMax;
        }

        public void AddReserve(float amount)
        {
            float difference = m_reserveAmmoMax - m_reserveAmount;
            if (amount > difference)
            {
                //re
            }
            m_reserveAmount += amount;
            m_noAmmo = false;
        }

    public void FillReserve()
    {
        m_reserveAmount = m_reserveAmmoMax;
        m_noAmmo = false;
    }

        public void SetReserveMax(float amount)
        {
            m_reserveAmmoMax = amount;
        }

        public bool CheckClip()
        {
            return m_reserveAmount <= 0;
        }

        public void Fillclip(float amount)
        {
            
        }

        public void CheckIfFireable(ref bool fire)
        {
            if (CheckClip())
            {
                fire = false;
                if(!m_noAmmo)
                {
                onNoAmmo?.Invoke();
                m_noAmmo = true;
                }
                else if(m_noAmmo && Time.time > (timeStamp + soundDelay))
            {
                timeStamp = Time.time;
                onFiringWithNoAmmo?.Invoke();
            }
            }
        }

        public void ReduceClip(float reduction)
        {
            m_reserveAmount -= reduction;
        }
    }

