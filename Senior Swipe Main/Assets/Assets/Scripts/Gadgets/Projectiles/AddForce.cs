using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class AddForce : MonoBehaviour
    {
        [SerializeField] private float m_force;

        private Rigidbody m_rd;



        private void Awake()
        {
            m_rd = GetComponentInChildren<Rigidbody>();
        }


        // Start is called before the first frame update
        void Start()
        {
            m_rd.AddForce(transform.forward * m_force + (transform.up * 250));
        }

    }
}
