using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> wavesList;
    int currentWaveIndex = 0;

    IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        currentWaveIndex = Random.Range(0, wavesList.Count);
        GameObject waveToSpawn = Instantiate(wavesList[currentWaveIndex].returnObstacleGroup(), transform.position, transform.rotation);
        yield return new WaitForSeconds(5);
    }

}
