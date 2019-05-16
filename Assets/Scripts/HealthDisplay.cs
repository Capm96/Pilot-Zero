using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // Script responsible for updating the player health display throughout the game.

    Text healthText;
    Player player;

    void Start()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        player = FindObjectOfType<Player>();
        healthText.text = player.GetHealth().ToString();

        if (player.GetHealth() <= 0) // Prevents player health from going below zero.
        {
            healthText.text = "0";
        } 
        else
        {
            healthText.text = player.GetHealth().ToString();
        }
    }
}
