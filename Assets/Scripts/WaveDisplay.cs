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
        waveText.text = gameSession.GetWave().ToString();
    }
}
