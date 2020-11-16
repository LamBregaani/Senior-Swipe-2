using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHitScan : MonoBehaviour
{
    public float enemyNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && enemyNumber > 0)
        {
            enemyNumber = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyNumber = 1;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyNumber = 0;
        }
    }
}
