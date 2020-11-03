using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIsReturned : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        var _player = collision.gameObject.GetComponentInParent<PlayerMovement>();

        if (_player != null)
        {
            Debug.Log("Returned");
            StoreCatSingleton.instance.catIsLaunched = false;
            Destroy(this.gameObject);
        }
    }
}
