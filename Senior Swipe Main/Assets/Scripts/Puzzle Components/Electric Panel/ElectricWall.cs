﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectricWall : MonoBehaviour, IAffectableByLaserPointer
{
    [SerializeField] private float r_shockTime;

    [SerializeField] private float r_coolDownTime;

    [SerializeField] private ParticleSystem[] w_particles;

    [SerializeField] private GameObject forceField;

    private bool r_canBeActivated = true;

    private bool r_isShocking;

    private float r_startTime;

    private Coroutine shockTimeCoroutine;

    [System.Serializable]
    public class ActiavtedEvent : UnityEvent { }
    
    [SerializeField] public ActiavtedEvent onActivated;

    void Awake()
    {
        w_particles = GetComponentsInChildren<ParticleSystem>();
    }

    //public void Update()
    //{
    //    if (Time.time > r_startTime + r_shockTime)
    //    {
    //        StartCoroutine(FenceCooldown());
    //    }
    //}

    public void LaserEffect()
    {
        foreach (ParticleSystem _part in w_particles)
        {
            r_startTime = Time.time;
            _part.Play();
            r_canBeActivated = false;
        }
        onActivated?.Invoke();
        StartCoroutine(FenceCooldown());
    }

    private IEnumerator FenceCooldown()
    {
        forceField.SetActive(true);
        foreach (ParticleSystem _part in w_particles)
        {
            _part.Stop();
            r_canBeActivated = true;
        }
        yield return new WaitForSeconds(r_coolDownTime);
        forceField.SetActive(false);
    }
}
