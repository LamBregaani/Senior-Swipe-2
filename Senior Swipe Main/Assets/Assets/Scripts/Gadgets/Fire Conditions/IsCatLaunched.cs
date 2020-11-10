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
        if(!CatIsLaunched() || StoreCatSingleton.instance.cat == null)
        {
            _fire = false;
        }
    }
}
