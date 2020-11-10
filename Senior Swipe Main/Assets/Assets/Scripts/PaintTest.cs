using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTest : MonoBehaviour
{
    private Camera cam;

    private List<Renderer> rends = new List<Renderer>();

    void Start()
    {
        
        cam = GetComponent<Camera>();

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            /*rends.Clear();

            RaycastHit[] hits = Physics.SphereCastAll(cam.ScreenPointToRay(Input.mousePosition), 1f);

            foreach (var hitObject in hits)
            {
                RaycastHit hit;

                

                Ray ray = new Ray(hitObject.point, hitObject.point - cam.transform.position);

                if (!Physics.Raycast(ray, out hit))
                    return;

                Renderer rend = hit.transform.GetComponent<Renderer>();
                Texture2D texture = Instantiate(rend.material.mainTexture) as Texture2D;
                rend.material.mainTexture = texture;
                MeshCollider meshCollider = hit.collider as MeshCollider;

                if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                    return;

                Texture2D tex = rend.material.mainTexture as Texture2D;
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;

                tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
                tex.Apply();


            }*/

            RaycastHit hit;
            if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
                return;

            Renderer rend = hit.transform.GetComponent<Renderer>();
            Texture2D texture = Instantiate(rend.material.mainTexture) as Texture2D;
            rend.material.mainTexture = texture;
            MeshCollider meshCollider = hit.collider as MeshCollider;

            if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                return;

            Texture2D tex = rend.material.mainTexture as Texture2D;
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
            tex.Apply();
        }
        else
        {
            RaycastHit hit;
            if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
                return;

            Renderer rend = hit.transform.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;

            if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                return;

            Texture2D tex = rend.material.mainTexture as Texture2D;
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            Color col = tex.GetPixel((int)pixelUV.x, (int)pixelUV.y);
            Debug.Log(col.ToString());
        }
    }
}
