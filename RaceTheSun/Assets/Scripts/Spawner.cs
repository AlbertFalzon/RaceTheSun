using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> wavesList;
    int currentWaveIndex = 0;
    int currentTimer = 120;
    float defaultDelay = 2f;

    IEnumerator Start()
    {
        while (true)
        {
            currentTimer = FindObjectOfType<Timer>().returnTimer();
            if ((currentTimer < 121) && (currentTimer > 105))
            {
                defaultDelay = 1.5f;
            } else if ((currentTimer < 106) && (currentTimer > 85))
            {
                defaultDelay = 1f;
            } else if ((currentTimer < 86) && (currentTimer > 60))
            {
                defaultDelay = 0.8f;
            } else if ((currentTimer < 61) && (currentTimer > 25))
            {
                defaultDelay = 0.65f;
            } else if (currentTimer < 26)
            {
                defaultDelay = 0.45f;
            }

            yield return StartCoroutine(SpawnWave(defaultDelay));
        }
    }

    private IEnumerator SpawnWave(float multiplier)
    {
        currentWaveIndex = Random.Range(0, wavesList.Count);
        GameObject waveToSpawn = Instantiate(wavesList[currentWaveIndex].returnObstacleGroup(), transform.position, transform.rotation);
        yield return new WaitForSeconds(multiplier * wavesList[currentWaveIndex].returnDelay());
    }

}
