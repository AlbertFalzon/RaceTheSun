using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScroll : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    List<float> currentSpeeds = new List<float>();
    Material terrain;
    Vector2 offset;
    
    void Start()
    {
        terrain = GetComponent<Renderer>().material;
        currentSpeeds = FindObjectOfType<Player>().returnSpeeds();
    }

    void Update()
    {
        currentSpeeds = FindObjectOfType<Player>().returnSpeeds();
        terrain.mainTextureOffset += new Vector2((currentSpeeds[1] /375) * Time.deltaTime, (-currentSpeeds[0] / 375) * Time.deltaTime);
    }
}
