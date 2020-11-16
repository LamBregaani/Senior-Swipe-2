using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySlimeObstacle : MonoBehaviour, IStickySlimeEffect
{
    public void StickyEffect()
    {
        this.gameObject.SetActive(false);
    }
}
