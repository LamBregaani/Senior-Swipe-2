using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageableByEnemy<T>
{
    void TakeDamage(T damageTaken);
}
