using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float camSpeed = 5f;

    void Update()
    {
        moveCamera();
    }

    private void moveCamera()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            var newXPos = new Vector3(-2.5f, 10f, -25f);
            this.transform.position = Vector3.MoveTowards(transform.position, newXPos, camSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            var newXPos = new Vector3(2.5f, 10f, -25f);
            this.transform.position = Vector3.MoveTowards(transform.position, newXPos, camSpeed * Time.deltaTime);
        } else
        {
            var newXPos = new Vector3(0f, 10f, -25f);
            this.transform.position = Vector3.MoveTowards(transform.position, newXPos, camSpeed/2 * Time.deltaTime);
        }
    }
}
