using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Wave Config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstacleGroup;

    public GameObject returnObstacleGroup()
    {
        return obstacleGroup;
    }
}
