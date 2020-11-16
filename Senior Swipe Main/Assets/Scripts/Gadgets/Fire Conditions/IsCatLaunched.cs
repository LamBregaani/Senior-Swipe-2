using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCatLaunched : MonoBehaviour, IFireCondition
{

    public bool CatIsLaunched()
    {
        return StoreCatSingleton.instance.catIsLaunched;
    }


    public void CheckIfFireable(ref bool _fire)
    {
        if (CatIsLaunched())
        {
            if (StoreCatSingleton.instance.catMain == null && StoreCatSingleton.instance.catProj == null)
            {
                _fire = false;
            }
               
        }
        else
            _fire = false;
    }
}
