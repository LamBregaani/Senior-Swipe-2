using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCatReturned : MonoBehaviour, IFireCondition
{
    

    public bool CatIsLaunched()
    {
        return StoreCatSingleton.instance.catIsLaunched;
    }


    public void CheckIfFireable(ref bool _fire)
    {
        if (CatIsLaunched())
        {
            _fire = false;
        }
    }
}
