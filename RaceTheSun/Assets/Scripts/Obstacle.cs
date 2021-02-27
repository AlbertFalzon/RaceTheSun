using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector3 currentPos;
    float currentSpeed;

    private void Start()
    {
        currentPos = transform.position;
    }

    void Update()
    {
        obstacleMove();
    }

    private void obstacleMove()
    {
        currentSpeed = FindObjectOfType<Player>().returnSpeed();
        currentPos = transform.position;
        currentPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * 75f;
        transform.position = currentPos;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPos.x, 0f, -100f), currentSpeed * Time.deltaTime);

        if(transform.position.z <= -100f)
        {
            Destroy(gameObject);
        }
    }
}
