using UnityEngine;
using System.Collections;

public class ScrollMove : MonoBehaviour
{
    public float scrollSpeed = 1.5f;
    Material myMaterial;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float newOffsetX = myMaterial.mainTextureOffset.x + (scrollSpeed * Time.deltaTime);
        float newOffsetY = myMaterial.mainTextureOffset.y + (scrollSpeed * Time.deltaTime);
        Vector2 newOffset = new Vector2(newOffsetX, newOffsetY);
        myMaterial.mainTextureOffset = newOffset;
    }
}