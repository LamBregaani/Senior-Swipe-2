using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSplat : MonoBehaviour
{
    [SerializeField] private int m_maxSplats;

    [SerializeField] private GameObject[] splats;

    private List<GameObject> m_spawnedSplats = new List<GameObject>();

    public void Spawn(Vector3 _point)
    {
        //Used to allow for different splats shapes and sizes
        int randomValue = Random.Range(0, splats.Length - 1);

        //Spawns the splat at the collision position
        var splat = Instantiate(splats[randomValue], _point, Quaternion.identity);

        //Sends the collision postion to the newly created splat
        var setUp = splat.GetComponent<OrientSplat>();

        setUp.SetUp(_point, this);
    }

    public void addSplat(GameObject splat)
    {
        m_spawnedSplats.Add(splat);
        if(m_spawnedSplats.Count > m_maxSplats)
        {
            var firstSplat = m_spawnedSplats[0];
            m_spawnedSplats.Remove(firstSplat);
            Destroy(firstSplat);
        }
    }
}
