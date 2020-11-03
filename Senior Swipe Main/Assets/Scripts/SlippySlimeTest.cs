using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlippySlimeTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var playerSpeed = collision.gameObject.GetComponent<ISlippySlimeEffect>();
        playerSpeed?.SlippySpeed(2);
    }

    private void OnCollisionExit(Collision collision)
    {
        var playerSpeed = collision.gameObject.GetComponent<ISlippySlimeEffect>();
        playerSpeed?.SlippySpeed(1);
    }
}
