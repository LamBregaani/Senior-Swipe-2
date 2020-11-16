using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class DestroyWeapon : MonoBehaviour
    {
        public void SetStats()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            Destroy(this.gameObject, 0.01f);
        }
    }

