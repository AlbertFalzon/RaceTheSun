using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 150f;
    float currentSpeed;
    float currentSideSpeed;
    List<float> speeds = new List<float>();

    [SerializeField] AudioClip explosionSound;
    [SerializeField] [Range(0, 5)] float explosionSoundVolume = 2;

    [SerializeField] GameObject shipExplosionEffect;
    float explosionDuration = 1f;

    [SerializeField] GameObject mainCamera;
    bool alive = true;

    private void OnTriggerEnter()
    {
        if (FindObjectOfType<Timer>().returnTimer() > 0)
        {
            alive = false;
            currentSpeed = 0f;
            playerExplode();
        }
    }

    private void playerExplode()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(explosionSound, mainCamera.transform.position, explosionSoundVolume);
        GameObject explosion = Instantiate(shipExplosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
        FindObjectOfType<Level>().loadGameOver();
    }

    private void Start()
    {
        currentSpeed = playerSpeed;
        currentSideSpeed = 0f;
        speeds.Add(currentSpeed);
        speeds.Add(currentSideSpeed);
    }

    void Update()
    {
        if (alive)
        {
            PlayerRotate();
            accelDecelForwards();
            accelDecelSideways();
        }
    }

    private void accelDecelForwards()
    {
        // Acceleration and deceleration for forwards movement
        if ((Input.GetAxis("Vertical") > 0) && (currentSpeed < 250f))
        {
            currentSpeed += 1f;
        }
        else if ((Input.GetAxis("Vertical") < 0) && (currentSpeed > 100f))
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

    private void accelDecelSideways()
    {
        // Less complex script for sideways movement to have sharper turns
        if (Input.GetAxis("Horizontal") != 0)
        {
            currentSideSpeed = -Input.GetAxis("Horizontal") * 75f;
        } else
        {
            currentSideSpeed = Convert.ToInt32(currentSideSpeed / 2f);
        }
    }

    // Method that rotates player and adjusts sideways movement speed
    private void PlayerRotate()
    {
        var targetAngle = Quaternion.Euler((Input.GetAxis("Horizontal") * -45f) - 90f, -90f, 90f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, 5f * Time.deltaTime);
    }

    public List<float> returnSpeeds()
    {
        speeds[0] = currentSpeed;
        speeds[1] = currentSideSpeed;
        return speeds;
    }

    public bool returnAlive()
    {
        return alive;
    }
}
