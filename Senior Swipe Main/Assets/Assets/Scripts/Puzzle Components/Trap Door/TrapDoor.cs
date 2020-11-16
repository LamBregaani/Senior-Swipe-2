using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Vector3 moveAmount;

    private Vector3 endPos;

    private Vector3 startPos;

    private Vector3 target;



    private void Awake()
    {
        startPos = transform.position;
        endPos = transform.position + moveAmount;
    }


    public void Drop()
    {
        target = endPos;
        StopAllCoroutines();
        StartCoroutine(MoveOverTime());

    }

    private IEnumerator MoveOverTime()
    {
        while (Vector3.Distance(transform.position, target) > 0.1) 
        {
            Move();
            yield return new WaitForEndOfFrame();
        }
    }

    private void Move()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    public void Lift()
    {
        target = startPos;
        StopAllCoroutines();
        StartCoroutine(MoveOverTime());

    }
}
