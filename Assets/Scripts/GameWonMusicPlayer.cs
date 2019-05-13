using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMusicPlayer : MonoBehaviour
{
    // Sets up singleton method for music player after game is won.

    Scene scene;
    int health;
    string currentScene;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpingleton();
    }

    void Start()
    {
        SetUpingleton();
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        CheckForScene();
    }

    private void SetUpingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void CheckForScene()
    {
        if (currentScene == "Main Menu" || currentScene == "Game")
        {
            Destroy(gameObject);
        }
    }
}
