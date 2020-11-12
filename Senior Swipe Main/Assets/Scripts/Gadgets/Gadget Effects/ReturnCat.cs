using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCat : MonoBehaviour, IGadgetEffect
{
    [SerializeField] private GameObject m_catReturnProj;


    public void GadgetEffect()
    {
        var _kitty = StoreCatSingleton.instance.catMain?.transform;
        if(_kitty != null)
        {
            Instantiate(m_catReturnProj, _kitty.position, _kitty.rotation);
            Destroy(_kitty.gameObject);
            
        }
        else
        {
            _kitty = StoreCatSingleton.instance.catProj.transform;
            Instantiate(m_catReturnProj, _kitty.position, _kitty.rotation);
            Destroy(_kitty.gameObject);
            
        }
        StoreCatSingleton.instance.catMain = null;
        StoreCatSingleton.instance.catProj = null;
    }
}
