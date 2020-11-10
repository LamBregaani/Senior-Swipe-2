using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveObjectToPlayer : MonoBehaviour
{
    [SerializeField] private float m_speed;

    private Transform m_player;



    private void Awake()
    {
        m_player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }


    private void FixedUpdate()
    {

        float _step = m_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_player.position, _step);
    }
}
