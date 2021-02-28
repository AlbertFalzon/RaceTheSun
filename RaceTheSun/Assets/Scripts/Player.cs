﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 150f;
    float currentSpeed;
    float turnSpeed = 5f;

    [SerializeField] AudioClip explosionSound;
    [SerializeField] [Range(0, 5)] float explosionSoundVolume = 2;

    [SerializeField] GameObject shipExplosionEffect;
    float explosionDuration = 1f;

    [SerializeField] GameObject mainCamera;
    bool alive = true;

    private void OnTriggerEnter()
    {
        print("Trigger Enter");
        alive = false;
        currentSpeed = 0f;
        playerExplode();
    }

    private void playerExplode()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(explosionSound, mainCamera.transform.position, explosionSoundVolume);
        GameObject explosion = Instantiate(shipExplosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
    }

    private void Start()
    {
        currentSpeed = playerSpeed;
    }

    void Update()
    {
        if (alive)
        {
            PlayerRotate();
            accelDecel();
        }
    }

    private void accelDecel()
    {
        // Acceleration and deceleration
        if ((Input.GetAxis("Vertical") > 0) && (currentSpeed <= 250f))
        {
            currentSpeed += 1f;
        }
        else if ((Input.GetAxis("Vertical") < 0) && (currentSpeed >= 100f))
        {
            currentSpeed -= 1f;
        }
        else
        {
            if (currentSpeed > 150f)
            {
                currentSpeed -= 1f;
            }
            else if (currentSpeed < 150f)
            {
                currentSpeed += 1f;
            }
        }
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

    public float returnSpeed()
    {
        return currentSpeed;
    }
}
