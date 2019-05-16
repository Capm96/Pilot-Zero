using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    // Displays current enemy wave.

    Text waveText;
    GameSession gameSession;

    void Start()
    {
        waveText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        int currentWave = gameSession.GetWave();
        int realWaveValue = currentWave + 1; // Our Enemy Wave Spawner starts counting from zero, so we have to add one. 

        waveText.text = realWaveValue.ToString();
    }
}
