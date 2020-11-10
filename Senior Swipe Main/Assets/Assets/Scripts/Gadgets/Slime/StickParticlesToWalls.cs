using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickParticlesToWalls : MonoBehaviour
{
    private List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    //private List<ParticleSystem.Particle> allEnter = new List<ParticleSystem.Particle>();

    private SpawnSplat splatManager;

    [SerializeField]private ParticleSystem ps;

    //[SerializeField]private ParticleSystem stickyPs;

    private void Awake()
    {
        splatManager = GetComponent<SpawnSplat>();
    }


    private void OnParticleTrigger()
    {
        
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, enter);

        //foreach (var p in enter)
        //{
        //    allEnter.Add(p);
        //}

        //int numEnter = allEnter.Count;

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.velocity = Vector3.zero;
            p.remainingLifetime = 0;
            enter[i] = p;
            splatManager.Spawn(p.position);
            //stickyPs.transform.position = enter[i].position;
            //stickyPs.Emit(1);
        }

        

        //for (int i = 0; i < numEnter; i++)
        //{
        
        //    ParticleSystem.Particle p = enter[i];
            
        //    enter[i] = p;
        //}
        
    }
}
