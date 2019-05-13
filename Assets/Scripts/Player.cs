using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Main player script.
    // Contains all methods and attributes concerning the main character's gameplay.
    
    // Configuration parameters.
    [Header("Player")]
    [SerializeField] GameObject playerLaser;
    [SerializeField] GameObject playerCharacter;
    [SerializeField] GameObject explosionParticles;
    [SerializeField] public float moveSpeed = 15f;
    [SerializeField] public int health = 1000;

    [Header("Projectile")]
    [SerializeField] public float projectileSpeed = 20f;
    [SerializeField] public float projectileFiringPeriod = 0.01f;

    [Header("Audio")]
    [SerializeField] AudioClip fireSFX;
    [SerializeField] [Range(0, 1)] float fireSFXVolume = 0.05f;
    [SerializeField] AudioClip deadSFX;
    [SerializeField] [Range(0, 1)] float deadSFXVolume = 0.75f;
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] [Range(0, 1)] float collisionSFXVolume = 0.75f;
    [SerializeField] AudioClip powerUpSFX;
    [SerializeField] [Range(0, 1)] float powerUpSFXVolume = 0.75f;

    // Declare variables.
    Coroutine firingCoroutine;

    float xMin, xMax, yMin, yMax;
    float movementPadding = 0.75f;
    public bool isPlayerDead = false;

    void Start()
    {
        SetUpMoveBoundaries(); // Limits player's movement within game walls.
    }

    void Update()
    {
        CheckForEnemies();

        if (isPlayerDead == false)
        {
            Move();
            Fire();
        }
    }

    private void CheckForEnemies() // Functionality which calls the enemiesDead() method in the spawner, allowing new wave to commence.
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            FindObjectOfType<EnemySpawner>().EnemiesDead();
        }
    }

    private void Fire() // Creates shooting functionality based on coroutines which allow player to hold down shooting button.
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously() // Coroutine that implements "hold and shoot" functionality based on projectileFiringPeriod.
    {
        while (true)
        {
            FindObjectOfType<GameSession>().AddToShotsFiredCount();

            GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireSFXVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move() // Creates movement function. Works with WASD or arrow keys.
    {
        // Makes input frame-independent
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Deliniates boundaries of movement. Padding used to create a range of movement within main camera only.
        // Since pivot point is at center of objects, no padding would mean portions of the ship would go off screen.
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin + movementPadding, xMax - movementPadding);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin + movementPadding, yMax - movementPadding);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries() // Transforms main camera boundaries (0,1) into float values.
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        playerLaser.transform.localScale = new Vector2(1, 1.3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser") || other.CompareTag("Enemy")) // Concerning interactions with enemies and enemy objects.
        {
            AudioSource.PlayClipAtPoint(collisionSFX, Camera.main.transform.position, collisionSFXVolume);
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
        }

        else if (other.CompareTag("Power Up")) // Concerning interactions with power ups.
        {
            AudioSource.PlayClipAtPoint(powerUpSFX, Camera.main.transform.position, collisionSFXVolume);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            isPlayerDead = true;
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(GameOver());
    }

    public int GetHealth()
    {
        return health;
    }

    public bool GetPlayerStatus()
    {
        return isPlayerDead;
    }

    public void LaserUpgrade(int damageIncrease, float scaleIncrease)
    {
        DamageDealer laserDamage = playerLaser.GetComponent<DamageDealer>();
        laserDamage.damage += damageIncrease;

        float xScale = playerLaser.transform.localScale.x;
        float yScale = playerLaser.transform.localScale.y;

        xScale += scaleIncrease;
        yScale += scaleIncrease;

        playerLaser.transform.localScale = new Vector2(xScale, yScale);
    }

    IEnumerator GameOver() // Initiates game over sequence if player is dead.
    {
        AudioSource.PlayClipAtPoint(deadSFX, Camera.main.transform.position, deadSFXVolume);

        Instantiate(explosionParticles, transform.position, transform.rotation);

        playerCharacter.GetComponent<Renderer>().enabled = false;
        playerCharacter.transform.position = new Vector2(1000f, -500f);
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Game Over");
    }
}