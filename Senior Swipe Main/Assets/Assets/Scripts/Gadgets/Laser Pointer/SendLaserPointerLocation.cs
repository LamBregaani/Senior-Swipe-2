using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendLaserPointerLocation : MonoBehaviour, ILaserPointerEffect
{
    public static event Action<bool> OnPlayerFiring = delegate { };

    public static event Action<Vector3> OnLaserHit = delegate { };

    public void PlayerIsFiring(bool _value)
    {
        OnPlayerFiring(_value);
    }

    public void LaserEffect(Vector3 _hitPoint)
    {
        OnLaserHit(_hitPoint);
    }
}
