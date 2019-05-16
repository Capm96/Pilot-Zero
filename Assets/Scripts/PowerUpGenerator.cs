using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    // Enables an empty game object to randomly instantiate the powerups.

    [SerializeField] List<GameObject> powerups;
    [SerializeField] float waitTimeBetweenPowerups = 60f;

    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimeBetweenPowerups);
            Instantiate(powerups[Random.Range(0, 4)], new Vector3(Random.Range(-5, 5), 10, 0), transform.rotation); 
        }
    }
}


