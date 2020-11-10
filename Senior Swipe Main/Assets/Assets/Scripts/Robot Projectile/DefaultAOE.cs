using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class DefaultAOE : MonoBehaviour, IFireSystem
    {
        
        [SerializeField] private float m_attackRadius;

        private Collider[] m_hitColliders;

        private IGadgetEffectWithTarget[] m_gadgetEffectScripts;

        [Tooltip("Decides what layers this weapon will check")]
        [SerializeField] private LayerMask mask;


        public delegate void TargetHit(GameObject hitObject);

        public event TargetHit targetHit;



        private void Awake()
        {
            m_gadgetEffectScripts = GetComponentsInChildren<IGadgetEffectWithTarget>();

        }

        private void OnEnable()
        {
            foreach (var gadgetEffect in m_gadgetEffectScripts)
            {
                targetHit += gadgetEffect.GadgetEffectWithTarget;
            }


        }

        private void OnDisable()
        {
            foreach (var gadgetEffect in m_gadgetEffectScripts)
            {
                targetHit -= gadgetEffect.GadgetEffectWithTarget;
            }
        }

        public void SetFirePoint(Transform point)
        {

        }

        public void Fire()
        {
            

            m_hitColliders = Physics.OverlapSphere(transform.position, m_attackRadius, mask);

            
            foreach (var objects in m_hitColliders)
            {
                targetHit?.Invoke(objects.gameObject);
            }
            
        }
    }

