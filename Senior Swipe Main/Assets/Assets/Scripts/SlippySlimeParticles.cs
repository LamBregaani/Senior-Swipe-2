using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlippySlimeParticles : MonoBehaviour
{
    ParticleSystem ps;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        var target = other.GetComponent<ISlippySlimeEffect>();
        target?.SlippySpeed(2.5f);
    }
}
