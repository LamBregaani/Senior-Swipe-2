using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSwing : MonoBehaviour, IFireSystem
{
    //public float state = 1;
    //public float value = 0;
    //public float fireRate = 1;
    //public float cooldown = 1;
    //float subtractPerSecond = 2;

    [SerializeField]private HammerHitScan hitScan;

    private HammerState hammerState;

    // Start is called before the first frame update
    void Awake()
    {
        hammerState = GetComponentInParent<HammerState>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(1) && cooldown == 1)
        //{
        //    value += 5;
        //}

        //if (value <= 15 && value >= 0)
        //{
        //    state = 1;
        //}

        //if (value <= 31 && value >= 16)
        //{
        //    state = 2;
        //}

        //if (value <= 45 && value >= 31)
        //{
        //    state = 3;
        //    value -= subtractPerSecond * Time.deltaTime;
        //}

        //if (value > 45)
        //{
        //    value = 45;
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (hammerState.currentState != HammerState.State.Uninflated && fireRate == 1)
        //    {
        //        Debug.Log("swing");
        //        fireRate = 0;
        //        Invoke("swing", 2);
        //    }

        //    if (value <= 15 && value >= 10 && cooldown == 1)
        //    {
        //        cooldown = 0;
        //        Invoke("cooldownTimer", 5);
        //    }

        //    if (value <= 30 && value >= 25 && cooldown == 1)
        //    {
        //        cooldown = 0;
        //        Invoke("cooldownTimer", 5);
        //    }
        //}
    }

    void Swing()
    {
        Debug.Log("swing");
    }

    //void cooldownTimer()
    //{
    //    cooldown = 1;
    //}

    public void Fire()
    {
        if (hammerState.currentState != HammerState.State.Uninflated)
        {
            Swing();
        }
    }

    public void SetFirePoint(Transform _point)
    {
        throw new System.NotImplementedException();
    }
}
