using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSingleton : MonoBehaviour
{
    public static SettingsSingleton instance;

    public float sensitivity;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
        
        DontDestroyOnLoad(this.gameObject);
    }


}
