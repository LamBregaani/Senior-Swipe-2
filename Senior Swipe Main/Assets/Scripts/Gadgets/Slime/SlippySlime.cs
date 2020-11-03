using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippySlime : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        var target = other.gameObject.GetComponentInParent<ISlippySlimeEffect>();
        target?.SlippySpeed(2.5f);
    }
}
