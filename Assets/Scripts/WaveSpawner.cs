using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;


    void Update()
    {
        if (countdown <= 0f)
        {
            spawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    
    void spawnWave()
    {
        Debug.Log("Wave Incoming");
    }

}
