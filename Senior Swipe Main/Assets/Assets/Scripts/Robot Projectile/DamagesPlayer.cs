using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagesPlayer : MonoBehaviour, IDamageableType
{

        public void CheckObject(float damage, GameObject hitObject, GameObject attackerObject)
        {
            IDamageableByEnemy<float> damageable = hitObject.GetComponentInParent<IDamageableByEnemy<float>>();

            if (damageable != null)
            {
                
                damageable.TakeDamage(damage);

            }
        }
    
}
