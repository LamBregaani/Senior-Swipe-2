using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectIfCatHitsGround : MonoBehaviour
{
    [System.Serializable]
    public class GroundHitEvent : UnityEvent { }

    [SerializeField] public GroundHitEvent onGroundHit;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        
        StoreCatSingleton.instance.catProj = this.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground or Wall"))
        {
            if (StoreCatSingleton.instance.catMain == null)
                onGroundHit?.Invoke();
            else
                Destroy(this.gameObject);
        }
    }
}
