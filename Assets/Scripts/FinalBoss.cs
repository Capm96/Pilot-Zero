using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    // Final boss script, which is a recycled version of the normal enemy script.
    // Primary difference are within the changes in main attributes & the instantiation of multiple lasers at once.

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

    public bool bossAlive = false;
    private float maxHealth = 25000f;
    private bool healthBarOn = false;
    GameObject healthBar;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        healthBar = GameObject.Find("Health Bar");
        StartCoroutine(SpawnHealthBar());
        healthBarOn = true;
    }

    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
        if (healthBarOn)
        {
            UpdateHealthBar(NormalizeHealthForDisplay(health));
        }
    }

    private void Fire() // Instantiates multiple lasers projectiles through different paths and their SFXs.
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        GameObject laser2 = Instantiate(projectile, new Vector2(transform.position.x - 1f, transform.position.y), Quaternion.identity) as GameObject;
        GameObject laser3 = Instantiate(projectile, new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity) as GameObject;
        GameObject laser4 = Instantiate(projectile, new Vector2(transform.position.x - 2f, transform.position.y), Quaternion.identity) as GameObject;
        GameObject laser5 = Instantiate(projectile, new Vector2(transform.position.x + 2f, transform.position.y), Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, -projectileSpeed);
        laser3.GetComponent<Rigidbody2D>().velocity = new Vector2(+1f, -projectileSpeed);
        laser4.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, -projectileSpeed);
        laser5.GetComponent<Rigidbody2D>().velocity = new Vector2(+2f, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireSFXVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) 
    {
        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() 
    {
        FindObjectOfType<GameSession>().AddToScore(enemyKillScore);
        bossAlive = true;
        StartCoroutine(GameWon());
        GameObject explosion = Instantiate(explosionParticles, transform.position, transform.rotation) as GameObject;
        GetComponent<SpriteRenderer>().enabled = false;
        transform.position = new Vector2(500f, 500f);   
        AudioSource.PlayClipAtPoint(deadSFX, Camera.main.transform.position, fireSFXVolume);
        Destroy(explosion, explosionDuration);
        healthBar.transform.position = new Vector3(0f, 8f, 2f);
        StartCoroutine(GameWon());
    }

    IEnumerator GameWon() // Loads game won screen after the boss is dead.
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Game Won Story");
    }

    IEnumerator SpawnHealthBar()
    {
        yield return new WaitForSeconds(2f);
        healthBar.transform.position = new Vector3(0f, 8f, 0f);
    }

    private float NormalizeHealthForDisplay(float currentHealth)
    {
        float normalizedHealth;

        return normalizedHealth = currentHealth / maxHealth;
    }

    private void UpdateHealthBar(float normalizedHealth)
    {
        healthBar.GetComponent<HealthBar>().SetSize(normalizedHealth);
    }
}
