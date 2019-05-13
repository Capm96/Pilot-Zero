using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    // Choose player functionality.

    [SerializeField] GameObject[] ships = new GameObject[3];
    [SerializeField] Sprite[] lightShipColors = new Sprite[4];
    [SerializeField] Sprite[] mediumShipColors = new Sprite[4];
    [SerializeField] Sprite[] heavyShipColors = new Sprite[4];

    public static int currentShipIndex = 1;
    public static int currentLightShipColorIndex = 0;
    public static int currentMediumShipColorIndex = 0;
    public static int currentHeavyShipColorIndex = 0;

    GameObject light;
    GameObject medium;
    GameObject heavy;

    static GameObject lightBars;
    static GameObject mediumBars;
    static GameObject heavyBars;

    void Awake()
    {
        light = GameObject.Find("PLight");
        medium = GameObject.Find("PMedium");
        heavy = GameObject.Find("PHeavy");
    }

    public void RightChooseShipButton()
    {
        currentShipIndex++;
        if (currentShipIndex > 2)
        {
            currentShipIndex = 0;
        }

        if (currentShipIndex == 0)
        {
            light.GetComponent<SpriteRenderer>().enabled = true;
            medium.GetComponent<SpriteRenderer>().enabled = false;
            heavy.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (currentShipIndex == 1)
        {
            light.GetComponent<SpriteRenderer>().enabled = false;
            medium.GetComponent<SpriteRenderer>().enabled = true;
            heavy.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (currentShipIndex == 2)
        {
            light.GetComponent<SpriteRenderer>().enabled = false;
            medium.GetComponent<SpriteRenderer>().enabled = false;
            heavy.GetComponent<SpriteRenderer>().enabled = true;
        }

        DisplayShipDescription();
        DisplayShipAttributes();
        DisplayShipName();
    }

    public void LeftChooseShipButton()
    {
        currentShipIndex--;
        if (currentShipIndex < 0)
        {
            currentShipIndex = 2;
        }

        if (currentShipIndex == 0)
        {
            light.GetComponent<SpriteRenderer>().enabled = true;
            medium.GetComponent<SpriteRenderer>().enabled = false;
            heavy.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (currentShipIndex == 1)
        {
            light.GetComponent<SpriteRenderer>().enabled = false;
            medium.GetComponent<SpriteRenderer>().enabled = true;
            heavy.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (currentShipIndex == 2)
        {
            light.GetComponent<SpriteRenderer>().enabled = false;
            medium.GetComponent<SpriteRenderer>().enabled = false;
            heavy.GetComponent<SpriteRenderer>().enabled = true;
        }

        DisplayShipDescription();
        DisplayShipAttributes();
        DisplayShipName();
    }

    public void RightColorButton()
    {
        if (currentShipIndex == 0)
        {
            if (currentLightShipColorIndex + 1 == 4)
            {
                currentLightShipColorIndex = -1;
            }
            currentLightShipColorIndex++;
            light.GetComponent<SpriteRenderer>().sprite = lightShipColors[currentLightShipColorIndex];
        }

        if (currentShipIndex == 1)
        {
            if (currentMediumShipColorIndex + 1 == 4)
            {
                currentMediumShipColorIndex = -1;
            }
            currentMediumShipColorIndex++;
            medium.GetComponent<SpriteRenderer>().sprite = mediumShipColors[currentMediumShipColorIndex];
        }

        if (currentShipIndex == 2)
        {
            if (currentHeavyShipColorIndex + 1 == 4)
            {
                currentHeavyShipColorIndex = -1;
            }
            currentHeavyShipColorIndex++;
            heavy.GetComponent<SpriteRenderer>().sprite = heavyShipColors[currentHeavyShipColorIndex];
        }
    }

    public void LeftColorButton()
    {
        if (currentShipIndex == 0)
        {
            if (currentLightShipColorIndex - 1 < 0)
            {
                currentLightShipColorIndex = 4;
            }
            currentLightShipColorIndex--;
            light.GetComponent<SpriteRenderer>().sprite = lightShipColors[currentLightShipColorIndex];
        }

        if (currentShipIndex == 1)
        {
            if (currentMediumShipColorIndex - 1 < 0)
            {
                currentMediumShipColorIndex = 4;
            }
            currentMediumShipColorIndex--;
            medium.GetComponent<SpriteRenderer>().sprite = mediumShipColors[currentMediumShipColorIndex];
        }

        if (currentShipIndex == 2)
        {
            if (currentHeavyShipColorIndex - 1 < 0)
            {
                currentHeavyShipColorIndex = 4;
            }
            currentHeavyShipColorIndex--;
            heavy.GetComponent<SpriteRenderer>().sprite = heavyShipColors[currentHeavyShipColorIndex];
        }
    }

    public static int GetCurrentShipIndex()
    {
        return currentShipIndex;
    }

    public static int GetCurrentColorIndex()
    {
        if (currentShipIndex == 0)
        {
            return currentLightShipColorIndex;
        }

        if (currentShipIndex == 1)
        {
            return currentMediumShipColorIndex;
        }

        if (currentShipIndex == 2)
        {
            return currentHeavyShipColorIndex;
        }

        return currentShipIndex;
    }

    public static void DisplayShipDescription()
    {
        GameObject lightDescription = GameObject.Find("Light Description");
        GameObject mediumDescription = GameObject.Find("Medium Description");
        GameObject heavyDescription = GameObject.Find("Heavy Description");

        if (currentShipIndex == 0)

        {
            lightDescription.GetComponent<TextMeshProUGUI>().enabled = true;
            mediumDescription.GetComponent<TextMeshProUGUI>().enabled = false;
            heavyDescription.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (currentShipIndex == 1)
        {
            lightDescription.GetComponent<TextMeshProUGUI>().enabled = false;
            mediumDescription.GetComponent<TextMeshProUGUI>().enabled = true;
            heavyDescription.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (currentShipIndex == 2)
        {
            lightDescription.GetComponent<TextMeshProUGUI>().enabled = false;
            mediumDescription.GetComponent<TextMeshProUGUI>().enabled = false;
            heavyDescription.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }

    public static void DisplayShipAttributes()
    {
        GameObject lightBars = GameObject.Find("Light Bar Attributes");
        GameObject mediumBars = GameObject.Find("Medium Bar Attributes");
        GameObject heavyBars = GameObject.Find("Heavy Bar Attributes");

        Vector3 inPosition = new Vector3(1.6f, 0f, 0f);
        Vector3 outPosition = new Vector3(1.6f, 0f, 5f);

        if (currentShipIndex == 0)
        {
            lightBars.transform.position = inPosition;
            mediumBars.transform.position = outPosition;
            heavyBars.transform.position = outPosition;
        }

        if (currentShipIndex == 1)
        {
            lightBars.transform.position = outPosition;
            mediumBars.transform.position = inPosition;
            heavyBars.transform.position = outPosition;
        }

        if (currentShipIndex == 2)
        {
            lightBars.transform.position = outPosition;
            mediumBars.transform.position = outPosition;
            heavyBars.transform.position = inPosition;
        }
    }

    public static void DisplayShipName()
    {
        GameObject lightName = GameObject.Find("Player Selector Canvas/Light Name");
        GameObject mediumName = GameObject.Find("Player Selector Canvas/Medium Name");
        GameObject heavyName = GameObject.Find("Player Selector Canvas/Heavy Name");

        if (currentShipIndex == 0)

        {
            lightName.GetComponent<TextMeshProUGUI>().enabled = true;
            mediumName.GetComponent<TextMeshProUGUI>().enabled = false;
            heavyName.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (currentShipIndex == 1)
        {
            lightName.GetComponent<TextMeshProUGUI>().enabled = false;
            mediumName.GetComponent<TextMeshProUGUI>().enabled = true;
            heavyName.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (currentShipIndex == 2)
        {
            lightName.GetComponent<TextMeshProUGUI>().enabled = false;
            mediumName.GetComponent<TextMeshProUGUI>().enabled = false;
            heavyName.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
