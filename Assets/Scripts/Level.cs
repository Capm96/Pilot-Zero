using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Primary scene loader script. Contains the functions used to move between scenes.

    [SerializeField] float delayInSeconds = 2f;

    public void LoadGameOver()
    {
        StartCoroutine(DelayGameOver());
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void GameIntroStory()
    {
        SceneManager.LoadScene("Game Intro Story");
    }

    public void GameWonStory()
    {
        SceneManager.LoadScene("Game Won Story");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GameWonFinalScene()
    {
        SceneManager.LoadScene("Game Won");
    }

    public void ChoosePlayer()
    {
        SceneManager.LoadScene("Choose Player");
    }
}
