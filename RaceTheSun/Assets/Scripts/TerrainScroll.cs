using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScroll : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    Material terrain;
    Vector2 offset;
    
    void Start()
    {
        terrain = GetComponent<Renderer>().material;
        scrollSpeed = FindObjectOfType<Player>().returnSpeed() / 375;
    }

    void Update()
    {
        scrollSpeed = -(FindObjectOfType<Player>().returnSpeed() / 375);
        terrain.mainTextureOffset += new Vector2(0f, scrollSpeed * Time.deltaTime);
    }
}
