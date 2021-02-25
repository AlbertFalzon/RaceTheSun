using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float turnSpeed = 5f;
    float maxCW = -135f;
    float maxCCW = -45f;

    void Update()
    {
        PlayerRotate();
    }

    private void PlayerRotate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            var targetAngle = Quaternion.Euler(-135f, -90f, 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, turnSpeed * Time.deltaTime);
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            var targetAngle = Quaternion.Euler(-45f, -90f, 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, turnSpeed * Time.deltaTime);
        } else
        {
            var targetAngle = Quaternion.Euler(-90f, -90f, 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, (turnSpeed / 5) * Time.deltaTime);
        }

    }
}
