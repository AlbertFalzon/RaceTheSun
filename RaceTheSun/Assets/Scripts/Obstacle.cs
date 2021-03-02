using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector3 currentPos;
    List<float> currentSpeeds = new List<float>();

    private void Start()
    {
        // Initialise variables
        currentPos = transform.position;
        currentSpeeds = FindObjectOfType<Player>().returnSpeeds();
    }

    void Update()
    {
        obstacleMove();
    }

    private void obstacleMove()
    {
        currentSpeeds = FindObjectOfType<Player>().returnSpeeds();
        currentPos.x += currentSpeeds[1] * Time.deltaTime;
        currentPos.z -= currentSpeeds[0] * Time.deltaTime;
        transform.position = currentPos;

        if(transform.position.z <= -500f)
        {
            Destroy(gameObject);
        }
    }
}
