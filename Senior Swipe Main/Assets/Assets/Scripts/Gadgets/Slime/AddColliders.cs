using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColliders : MonoBehaviour
{
    private ParticleSystem ps;

    private int index;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }


    private void OnParticleCollision(GameObject other)
    {

        var otherCollider = other.GetComponent<Collider>();

        if(other.CompareTag("Ground or Wall"))
        {
            ps.trigger.SetCollider(index, otherCollider);
            index++;
            if (index > 5)
                index = 0;
        }
    }
}
