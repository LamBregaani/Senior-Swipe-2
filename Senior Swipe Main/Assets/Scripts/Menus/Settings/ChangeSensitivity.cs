using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSensitivity : MonoBehaviour
{

    public void Sensitivity(float value)
    {
        SettingsSingleton.instance.sensitivity = value;
    }
}
