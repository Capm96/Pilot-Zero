using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Spawns player according to user input.

    [SerializeField] GameObject[] ships = new GameObject[3];
    [SerializeField] Sprite[] lightShipColors = new Sprite[4];
    [SerializeField] Sprite[] mediumShipColors = new Sprite[4];
    [SerializeField] Sprite[] heavyShipColors = new Sprite[4];

    void Start()
    {
        int playerModel = PlayerSelector.currentShipIndex;
        int colorModel = PlayerSelector.GetCurrentColorIndex();

        Vector3 pos = new Vector3(0f, -8f, 0f);

        FindObjectOfType<GameSession>().ResetGameStatus();

        SpawnPlayer(playerModel, colorModel, pos);
    }

    private void SpawnPlayer(int playerModel, int colorModel, Vector3 spawnPos)
    {
        if (playerModel == 0)
        {
            GameObject player = Instantiate(ships[0], spawnPos, Quaternion.identity) as GameObject;
            switch (colorModel)
            {
                case 0:
                    player.GetComponent<SpriteRenderer>().sprite = lightShipColors[0];
                    break;
                case 1:
                    player.GetComponent<SpriteRenderer>().sprite = lightShipColors[1];
                    break;
                case 2:
                    player.GetComponent<SpriteRenderer>().sprite = lightShipColors[2];
                    break;
                case 3:
                    player.GetComponent<SpriteRenderer>().sprite = lightShipColors[3];
                    break;
            }
        }

        if (playerModel == 1)
        {
            GameObject player = Instantiate(ships[1], spawnPos, Quaternion.identity) as GameObject;
            switch (colorModel)
            {
                case 0:
                    player.GetComponent<SpriteRenderer>().sprite = mediumShipColors[0];
                    break;
                case 1:
                    player.GetComponent<SpriteRenderer>().sprite = mediumShipColors[1];
                    break;
                case 2:
                    player.GetComponent<SpriteRenderer>().sprite = mediumShipColors[2];
                    break;
                case 3:
                    player.GetComponent<SpriteRenderer>().sprite = mediumShipColors[3];
                    break;
            }
        }

        if (playerModel == 2)
        {
            GameObject player = Instantiate(ships[2], spawnPos, Quaternion.identity) as GameObject;
            switch (colorModel)
            {
                case 0:
                    player.GetComponent<SpriteRenderer>().sprite = heavyShipColors[0];
                    break;
                case 1:
                    player.GetComponent<SpriteRenderer>().sprite = heavyShipColors[1];
                    break;
                case 2:
                    player.GetComponent<SpriteRenderer>().sprite = heavyShipColors[2];
                    break;
                case 3:
                    player.GetComponent<SpriteRenderer>().sprite = heavyShipColors[3];
                    break;
            }
        }
    }
}
