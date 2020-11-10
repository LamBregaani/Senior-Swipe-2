using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLaunched : MonoBehaviour, IGadgetEffect
{
    public void GadgetEffect()
    {
        StoreCatSingleton.instance.catIsLaunched = true;
    }
}
