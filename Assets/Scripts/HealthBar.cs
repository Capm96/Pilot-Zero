using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject barDisplay;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSize(float sizeNormalized)
    {
        bar.transform.localScale = new Vector2(sizeNormalized, 1f);
        UpdateColor(sizeNormalized);
    }

    public void UpdateColor(float sizeNormalized)
    {
        if (sizeNormalized < 0.70 && sizeNormalized > 0.30)
        {
            barDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (sizeNormalized < 0.30)
        {
            barDisplay.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
