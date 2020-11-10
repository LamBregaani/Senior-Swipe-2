using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IWeaponClipType
    {
    float CurrentAmmo();

    float MaxAmmo();

        void Fillclip(float amount);

        void ReduceClip(float reduction);

        void AddReserve(float amount);

        bool CheckClip();

        void SetReserveMax(float amount);
    }

