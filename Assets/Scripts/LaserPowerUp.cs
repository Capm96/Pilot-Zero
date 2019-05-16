using UnityEngine;

public class LaserPowerUp : MonoBehaviour
{
    // Laser projectile damage power up script. Functionally equivalent to all other power up scripts.

    [SerializeField] int projectileDamageIncrease = 25;
    [SerializeField] float laserSpriteScaleIncrease = 0.80f;
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
        playerCharacter.LaserUpgrade(projectileDamageIncrease, laserSpriteScaleIncrease);

        Destroy(gameObject);
    }
}
