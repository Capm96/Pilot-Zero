using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicPlayer : MonoBehaviour 
{
    Scene scene;
    int health;
    string currentScene;

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
        if (currentScene == "Game Intro Story")
        {
            Destroy(gameObject);
        }
    }
}

