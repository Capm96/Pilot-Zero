using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonStoryLoader : MonoBehaviour
{
    //Allows player to skip the story.

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Game Won");
        }
    }
}
