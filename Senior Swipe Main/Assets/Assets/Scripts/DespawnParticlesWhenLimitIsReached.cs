using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnParticlesWhenLimitIsReached : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;
 
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    void Update()
    {
        var count = ps.GetParticles(particles);
        if (count >= ps.main.maxParticles)
        {
            var index = 0;
            float lifeTime = particles[0].remainingLifetime;
            for (var i = 0; i < count; i++)
            {
                if (particles[i].remainingLifetime < lifeTime)
                {
                    lifeTime = particles[i].remainingLifetime;
                    index = i;
                }
            }
            particles[index].remainingLifetime = -1.0f;
            ps.SetParticles(particles, count);
        }
    }
}
