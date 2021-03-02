using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Wave Config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstacleGroup;
    [SerializeField] float delay = 0f;

    public GameObject returnObstacleGroup()
    {
        return obstacleGroup;
    }

    public float returnDelay()
    {
        return delay;
    }
}
