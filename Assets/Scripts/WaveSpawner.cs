using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
    public Text waveCountdownText;
    public GameObject waveCountdownUI;
    private int bossCount = 0;

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    private int waveIndex = 0;

	void Update () 
	{
        if (EnemiesAlive > 0)
        {
            waveCountdownUI.SetActive(false);
            return;
        }

		if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        waveCountdownUI.SetActive(true);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
  
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemies);

            if (wave.boss != null && bossCount < 1)
            {
                bossCount++;
                EnemiesAlive++;
                StartCoroutine(SpawnBoss(wave.boss, wave.bossSpawnTime));
            }

            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject[] enemies)
    {

        foreach (GameObject enemy in enemies)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }       
    }

    IEnumerator SpawnBoss(GameObject boss, float spawnRate)
    {
        yield return new WaitForSeconds(spawnRate);
        Debug.Log("Boss Spawned");
        Instantiate(boss, spawnPoint.position, spawnPoint.rotation);
    }
}
