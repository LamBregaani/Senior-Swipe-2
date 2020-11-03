using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSingleton : MonoBehaviour
{
    public static SettingsSingleton instance;

    public float sensitivity;

    public void Sensitivity(float value)
    {
        sensitivity = value;
    }

    public void Awake()
    {
        instance = this;
    }


}
