using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Main enemy script.
    // Contains the essential data container for enemy information.
    // Contains main methods associated with enemies.

    // Configuration Parameters.
    [Header("Enemy Stats")]
    [SerializeField] int health = 100;
    [SerializeField] int enemyKillScore = 150;

    [Header("Shooting")]
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject explosionParticles;
    [SerializeField] float shotCounter;
    [SerializeField] float projectileSpeed;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float explosionDuration = 1f;

    [Header("Audio")]
    [SerializeField] AudioClip fireSFX;
    [SerializeField] [Range(0, 1)] float fireSFXVolume = 0.75f;
    [SerializeField] AudioClip deadSFX;
    [SerializeField] [Range(0, 1)] float deadSFXVolume = 0.75f;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots); // Creates a random shooting pattern.
    }

    void Update()
    {
        shotCounter -= Time.deltaTime; // Locks enemy shooting to be time bound by a variable -- the greater the shotCounter, the longer it takes to shoot.
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots); // Restarts shotCounter.
        }
    }

    private void Fire() // Instantiates laser projectiles and their SFX.
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireSFXVolume);
    }

    private void OnTriggerEnter2D(Collider2D other) // Initiates the damage-intake procedure upon collision.
    {
        if (other.gameObject.tag == "Player")
        {
            Die();
        }
        else
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer) { return; }
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer) // Subtract damage from health until it reaches 0 -- initiating death method.
    {
        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }   

    private void Die() // Adds to player score, destroys enemy game object, instantiates SFX/VFX.
    {
        FindObjectOfType<GameSession>().AddToScore(enemyKillScore);
        FindObjectOfType<GameSession>().AddToEnemiesKilled();
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionParticles, transform.position, transform.rotation) as GameObject;
        AudioSource.PlayClipAtPoint(deadSFX, Camera.main.transform.position, fireSFXVolume);
        Destroy(explosion, explosionDuration);
    }
}
