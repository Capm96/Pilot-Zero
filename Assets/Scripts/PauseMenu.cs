    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Creates methods for interaction during the pause menu throughout the main gameplay.

    // Configuration parameters.
    public GameObject PauseMenuUI;
    public GameObject InstructionsUI;
    public GameObject sprites;

    public static bool gameIsPaused = false;
    public static bool musicIsPaused = false;
    public static bool instructionsAreOn = false;
    public static bool spritesAreOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused && !instructionsAreOn)
            {
                Resume();
            }
            else if (gameIsPaused && instructionsAreOn)
            {
                Instructions();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Freezes time.
        PauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Unfreezes time.
        PauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseMusic()
    {
        if (musicIsPaused == false)
        {
            AudioListener.volume = 0;
            musicIsPaused = true;
        }
        else
        {
            AudioListener.volume = 1;
            musicIsPaused = false;
        }
    }

    public void Instructions()
    {
        if (instructionsAreOn == false)
        {
            PauseMenuUI.SetActive(false);
            InstructionsUI.SetActive(true);
            sprites.SetActive(true);
            instructionsAreOn = true;
        }
        else
        {
            PauseMenuUI.SetActive(true);
            InstructionsUI.SetActive(false);
            sprites.SetActive(false);
            instructionsAreOn = false;
        }
    }
}
