using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Material terrain;
    Vector2 offset;
    
    void Start()
    {
        terrain = GetComponent<Renderer>().material;
        offset = new Vector2(0f, scrollSpeed);
    }

    void Update()
    {
        terrain.mainTextureOffset += offset * Time.deltaTime;
    }
}
