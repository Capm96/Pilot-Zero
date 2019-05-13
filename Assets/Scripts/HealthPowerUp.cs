using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    // Health power up script. Functionally equivalent to all other power up scripts.
    
    // Configuration Parameters
    [SerializeField] int healthIncrease = 300;
    [SerializeField] GameObject PowerUpEffect;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    private void PickUp(Collider2D player)
    {
        GameObject effect = Instantiate(PowerUpEffect, transform.position, transform.rotation);

        Player playerCharacter = player.GetComponent<Player>();
        playerCharacter.health = playerCharacter.health + healthIncrease;

        Destroy(gameObject);
    }
}
