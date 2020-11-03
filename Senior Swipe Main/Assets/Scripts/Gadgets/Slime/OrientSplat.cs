using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientSplat : MonoBehaviour
{
    [SerializeField] private LayerMask splatLayer;

    [SerializeField] private LayerMask environmentLayers;

    [SerializeField] private Collider[] hitObjects;

    private Vector3 normal;

    public void SetUp(Vector3 _point, SpawnSplat spawnSplat)
    {
        hitObjects = Physics.OverlapSphere(transform.position, 0.1f, splatLayer);
        if (hitObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        RaycastHit hit;


        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        //if (Physics.Raycast(transform.position, (transform.position + _point).normalized, out hit, 0.5f, environmentLayers))
        //{
        //    Debug.Log("hit");
        //    normal = hit.normal.normalized;
        //    transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        //    spawnSplat.addSplat(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
        //Debug.DrawRay(transform.position, (transform.position + _point), Color.green, 100);

        hitObjects = Physics.OverlapSphere(transform.position, 1f, environmentLayers);
        if (hitObjects.Length > 0)
        {
            var direction = (transform.position - hitObjects[0].transform.position).normalized;
            if (Physics.Raycast(transform.position, -direction, out hit, 1f, environmentLayers))
            {
                Debug.DrawRay(transform.position, -direction, Color.green, 100);
                normal = hit.normal.normalized;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
                
            }
            else
            {
                Debug.DrawRay(transform.position, -direction, Color.red, 100);
                //Destroy(this.gameObject);
            }
            spawnSplat.addSplat(this.gameObject);
            //Debug.Log("rotation");
            //var faceDir = -(this.transform.position - _point);
            //this.transform.rotation = hitObjects[0].transform.rotation;
            //Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normal);
            //transform.rotation = rotation;
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);

            //transform.up = faceDir;
            //spawnSplat.addSplat(this.gameObject);
        }
            
    }
}
