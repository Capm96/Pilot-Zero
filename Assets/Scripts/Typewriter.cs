using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    // Allows for game story text to be laid out one character at a time.

    public Text textComponent;
    public string text;
    public float timeCounter;
    public float timeLapse;

    void Start()
    {
        StartCoroutine(BuildText());
    }

    private IEnumerator BuildText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textComponent.text = string.Concat(textComponent.text, text[i]);
            // Waits a certain amount of time between each character written, then continue with the for loop.
            yield return new WaitForSeconds(timeLapse);
        }
    }
}
