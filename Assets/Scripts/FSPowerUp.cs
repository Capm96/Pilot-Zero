using UnityEngine;

public class FSPowerUp : MonoBehaviour
{
    // Fire speed power up script.

    // Configuration parameters.
    [SerializeField] float fireSpeedIncrease = 1.30f;
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
        GameObject effect = Instantiate(PowerUpEffect, transform.position, transform.rotation); // Creates pick-up particle effects.

        Player playerCharacter = player.GetComponent<Player>();
        playerCharacter.projectileFiringPeriod = playerCharacter.projectileFiringPeriod / fireSpeedIncrease; // Pick-ups last indefinitely.

        Destroy(gameObject);
    }
}


