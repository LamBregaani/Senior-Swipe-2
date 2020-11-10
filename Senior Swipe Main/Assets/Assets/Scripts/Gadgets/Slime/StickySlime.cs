using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySlime : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<IStickySlimeEffect>();
        target?.StickyEffect();
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
