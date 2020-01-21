using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float StartTime;
    public SpawnWaveType[] WavesObjects;
    private float nextWave;
    private float nextSpawn;
    private float halfWidth;
    private int countObjects;
    private int countWaves;
    private SpawnWaveType WaveObjects;
    private GameObject spawnObject;
    private int indexWave;

    private void Start()
    {
        halfWidth = transform.localScale.x * 0.5f;
        countWaves = WavesObjects.Length;
        nextWave = StartTime + Time.time;
        RegimeWave();
    }

    public void DroppingWave()
    {
        indexWave = 0;
        nextWave = StartTime + Time.time;
    }

    private void RegimeWave()
    {
        if (indexWave < countWaves)
        {
            WaveObjects = WavesObjects[indexWave++];
            countObjects = WaveObjects.spawnObjects.Length;
            nextSpawn = nextWave + Random.Range(WaveObjects.minDelay, WaveObjects.maxDelay);
            nextWave += WaveObjects.TimeWave;
        }
        else
        {
            nextWave *= 1000;
        }
    }

    void Update()
    {
        if (!GameController.isInstance().GetIsStarted())
        {
            return ;
        }

        if (Time.time > nextWave)
        {
            RegimeWave();
        }

        if (Time.time > nextSpawn)
        {
            if (countObjects == 1)
            {
                spawnObject = WaveObjects.spawnObjects[0];
            }
            else
            {
                spawnObject = WaveObjects.spawnObjects[Random.Range(0, countObjects)];
            }
            nextSpawn = Time.time + Random.Range(WaveObjects.minDelay, WaveObjects.maxDelay);
            Instantiate(
                spawnObject,
                new Vector3(
                    Random.Range(-halfWidth, halfWidth),
                    transform.position.y,
                    transform.position.z),
                spawnObject.transform.rotation);
        }
    }
}
