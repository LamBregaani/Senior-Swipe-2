using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSplat : MonoBehaviour
{
    [SerializeField] private int m_maxSplats;

    [SerializeField] private GameObject[] splats;

    private List<GameObject> spawnedSplats = new List<GameObject>();

    public void Spawn(Vector3 _point)
    {

        int randomValue = Random.Range(0, splats.Length - 1);

        var splat = Instantiate(splats[randomValue], _point, Quaternion.identity);

        var setUp = splat.GetComponent<OrientSplat>();

        setUp.SetUp(_point, this);
    }

    public void addSplat(GameObject splat)
    {
        spawnedSplats.Add(splat);
        if(spawnedSplats.Count > m_maxSplats)
        {
            var firstSplat = spawnedSplats[0];
            spawnedSplats.Remove(firstSplat);
            Destroy(firstSplat);
        }
    }
}
