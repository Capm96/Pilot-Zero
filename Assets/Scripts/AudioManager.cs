using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Responsible for audio component during core gameplay.
    // Changes songs after they are done & introduces boss' theme song.

    // Configuration parameters.
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] List<AudioClip> songs;
    [SerializeField] GameObject bossMusicPlayer;

    // Declare variables.
    GameSession gameSession;
    int bossWave = 25;
    int currentWave;
    bool bossAlive = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayNormalMusic());
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = gameSession.GetWave();

        if (bossWave == currentWave)
        {
            Instantiate(bossMusicPlayer, new Vector3(0, 0, 0), Quaternion.identity); 
            Destroy(gameObject); 
            currentWave = 100; // Because this function is on update, audio would be continuously started over (boss wave == current wave),
                               // Therefore I moved the current wave to a different number so that the music would not be refreshed.
        }
    }

    IEnumerator PlayNormalMusic() // Plays a song until it is done, then moves on to the next.
    {
        for (int i = 0; i < songs.Count; i++)
        {
            backgroundMusic.clip = songs[i];
            backgroundMusic.Play();
            yield return new WaitForSeconds(backgroundMusic.clip.length);
        }
    }
}
