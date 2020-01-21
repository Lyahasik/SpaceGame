using UnityEngine;

[System.Serializable]
public class SpawnWaveType
{
    public GameObject[] spawnObjects;
    public float minDelay = 1.0f;
    public float maxDelay = 3.0f;
    public float TimeWave;
}
