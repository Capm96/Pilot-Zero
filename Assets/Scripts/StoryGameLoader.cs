using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameLoader : MonoBehaviour
{
    // Allows player to skip game story scene.

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
