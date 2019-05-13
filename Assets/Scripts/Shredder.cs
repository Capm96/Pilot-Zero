using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Destroys lasers that go out of main camera so as to not convolute the game hierarchy and slow down the game.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
