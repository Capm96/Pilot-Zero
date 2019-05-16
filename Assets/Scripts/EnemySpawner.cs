using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Declares main methods associated with spawning enemies.

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    [SerializeField] float waveWaitTime = 5f;
    [SerializeField] bool enemiesAlive = true;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves()); 
        }
        while (looping); // Allows possibility to generate infinite waves. Normal gameplay does not have this feature.
    }

    private IEnumerator SpawnAllWaves() // Creates a loop that spawns enemy an until enemies in that wave are destroyed.
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            enemiesAlive = true;
            var currentWave = waveConfigs[waveIndex];
            StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            FindObjectOfType<GameSession>().AddWave();
            yield return new WaitUntil(() => enemiesAlive == false); // This will be turned false through the player game object,
                                                                     // Which has a method to check for enemies in the screen and
                                                                     // Update enemiesAlive if there are none left.
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) // Creates a loop to spawn all enemies within a wave.
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.tag = "Enemy"; 
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig); // Sets current pathing to be according to current wave.
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()); // Time between spawns is dependent on a variable.
        }
    }

    public void EnemiesDead() // Function which is called by the player game object when there are no enemies left.
    {
        enemiesAlive = false;
    }
}
