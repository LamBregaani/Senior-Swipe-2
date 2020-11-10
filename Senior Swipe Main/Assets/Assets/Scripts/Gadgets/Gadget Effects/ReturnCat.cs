using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCat : MonoBehaviour, IGadgetEffect
{
    [SerializeField] private GameObject m_catReturnProj;


    public void GadgetEffect()
    {
        var _kitty = StoreCatSingleton.instance.cat.transform;
        Instantiate(m_catReturnProj, _kitty.position, _kitty.rotation);
        Destroy(_kitty.gameObject);
        StoreCatSingleton.instance.cat = null;
    }
}
