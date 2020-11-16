using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireCondition
{
    void CheckIfFireable(ref bool _fire);
}
