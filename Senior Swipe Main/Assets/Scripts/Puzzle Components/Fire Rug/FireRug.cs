using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRug : MonoBehaviour
{
    [SerializeField] private float r_burnTime;

    [SerializeField] private float r_sizzleTime;

    [SerializeField] private ParticleSystem[] r_particles;

    [SerializeField] private GameObject fireCollider;

    private bool r_cantBeBurned = true;

    private float r_startTime;

    private Coroutine burnTimeCoroutine;

    private object obj;

    void Awake()
    {
        r_particles = GetComponentsInChildren<ParticleSystem>();
    }
    //public void Update()
    //{
    //    if (Time.time > r_startTime + r_burnTime)
    //    {
    //        StartCoroutine(RemoveAfterSeconds());
    //    }
    //}

    public void SetOnFire()
    {
        foreach (ParticleSystem _part in r_particles)
        {
            r_startTime = Time.time;
            _part.Play();
            r_cantBeBurned = false;
        }
        fireCollider.SetActive(true);
    }

    //private IEnumerator RemoveAfterSeconds()
    //{
    //    yield return new WaitForSeconds(r_sizzleTime);
    //    r_cantBeBurned = true;
    //    Destroy(this.gameObject);
    //}
}
