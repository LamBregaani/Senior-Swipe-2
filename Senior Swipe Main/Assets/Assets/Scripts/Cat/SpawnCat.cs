using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCat : MonoBehaviour
{
    [SerializeField] private GameObject m_cat;

    public void CatSpawn()
    {
        var catClone = Instantiate(m_cat, transform.position, transform.rotation);

        StoreCatSingleton.instance.cat = catClone;

        Destroy(this.gameObject);
    }
}
