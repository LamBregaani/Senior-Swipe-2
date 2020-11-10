using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCatSingleton : MonoBehaviour
{
    public bool catIsLaunched;

    public GameObject cat { get; set; }



    public static StoreCatSingleton instance;

    private void Awake()
    {
        if (instance != null)
            instance = this;
        else
            instance = this;
    }
}
