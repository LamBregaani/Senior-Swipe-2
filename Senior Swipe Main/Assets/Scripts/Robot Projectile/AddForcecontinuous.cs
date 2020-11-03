using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class AddForcecontinuous : MonoBehaviour
    {
        private Rigidbody rd;

        [SerializeField] private float force;


        private void Awake()
        {
            rd = GetComponent<Rigidbody>();
        }


        // Start is called before the first frame update
        void Start()
        {
            rd.AddForce(transform.forward * force);
        }

    }

