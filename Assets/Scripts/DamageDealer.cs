using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Establishes damage information for all in-game collisions between enemies, players, and their lasers. 

    public int damage = 100;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
