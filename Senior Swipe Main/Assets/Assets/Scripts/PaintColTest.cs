using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintColTest : MonoBehaviour
{
    Texture2D tex;

    Vector2 pixelUV;

    void OnCollisionEnter(Collision collisionInfo)
    {
        
        Renderer rend = collisionInfo.gameObject.GetComponent<Renderer>();
        if(rend.material.mainTexture != null)
        {
            tex = Instantiate(rend.material.mainTexture) as Texture2D;
            rend.material.mainTexture = tex;
        }


        foreach (ContactPoint cp in collisionInfo.contacts)
        {
            RaycastHit hit;
            float rayLength = 1f;
            Ray ray = new Ray(cp.point - cp.normal * rayLength * 0.5f, cp.normal);
            Color C = Color.white; // default color when the raycast fails for some reason ;)
            if (cp.otherCollider.Raycast(ray, out hit, rayLength))
            {

                pixelUV = hit.textureCoord;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;

                tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
                tex.Apply();
                C = tex.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);
            }
            // Instantiate your effect and
            // use the color C
        }
    }
}
