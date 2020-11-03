using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectIfCatHitsGround : MonoBehaviour
{
    [System.Serializable]
    public class GroundHitEvent : UnityEvent { }

    [SerializeField] public GroundHitEvent onGroundHit;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground or Wall"))
        {
            onGroundHit?.Invoke();
        }
    }
}
