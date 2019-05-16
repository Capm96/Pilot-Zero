using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameLoader : MonoBehaviour
{
    // Allows player to skip the game stories by pressing the space key.

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
