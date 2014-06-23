using UnityEngine;
using System.Collections;

public class TextCoord : MonoBehaviour {
    

    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        Renderer renderer = hit.collider.renderer;
        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (renderer == null || renderer.sharedMaterial == null || renderer.sharedMaterial.mainTexture == null || meshCollider == null)
            return;

        Texture2D tex = (Texture2D)renderer.material.mainTexture;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        tex.Apply();
    }
}
