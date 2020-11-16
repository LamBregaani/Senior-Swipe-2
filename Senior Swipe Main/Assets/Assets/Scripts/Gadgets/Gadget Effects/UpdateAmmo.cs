using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UpdateAmmo : MonoBehaviour
{
    [SerializeField] private int _ammoCost;

    private IWeaponClipType _clipType;

    [System.Serializable]
    public class EnergyChangedEvent : UnityEvent<float,float> { }

    public EnergyChangedEvent onEnergyChanged;

    private void Awake()
    {
        _clipType = GetComponent<IWeaponClipType>();
    }


    public void ReduceAmmo()
    {   
        _clipType.ReduceClip(_ammoCost);
        AmmoChanged();
    }

    public void WeaponEffect()
    {
    _clipType.ReduceClip(Time.deltaTime);
    AmmoChanged();
    }

    public void AmmoChanged() => onEnergyChanged.Invoke(_clipType.CurrentAmmo(), _clipType.MaxAmmo());
     


    public void SetStats()
    {
        throw new System.NotImplementedException();
    }
}

