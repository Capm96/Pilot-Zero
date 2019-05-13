using UnityEngine;

public class GameSession : MonoBehaviour
{
    // The GameSession script is primarily responsible for carrying the score and wave numbers throughout the scenes in the game.

    // Declare initial variables.
    int score = 0;
    int waveNumber = 0;
    int shotsFired = 0;
    int enemiesKilled = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton() // To maintain game object throughout scenes and prevent numbers from reseting.
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void AddWave()
    {
       waveNumber++;
    }

    public int GetWave()
    {
        return waveNumber;
    }

    public void AddToShotsFiredCount()
    {
        shotsFired++;
    }

    public int GetShotsFired()
    {
        return shotsFired;
    }

    public void AddToEnemiesKilled()
    {
        enemiesKilled++;
    }

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    public void ResetGameStatus()
    {
        score = 0;
        waveNumber = 0;
        shotsFired = 0;
        enemiesKilled = 0;
    }
}
