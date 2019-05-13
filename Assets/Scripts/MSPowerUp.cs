using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSPowerUp : MonoBehaviour
{
    // Movement speed power up script. Functionally equivalent to all other power up scripts.

    // Configuration Parameters
    [SerializeField] float moveSpeedIncrease = 1.15f;
    [SerializeField] GameObject PowerUpEffect;

    void OnTriggerEnter2D(Collider2D other)
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
        playerCharacter.moveSpeed = playerCharacter.moveSpeed * moveSpeedIncrease;

        Destroy(gameObject);
    }
}
