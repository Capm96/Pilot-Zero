using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject barDisplay;

    public void SetSize(float sizeNormalized) // Reduces size of the Boss' health bar to a scale between 0 and 1 (0% to 100% full).
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
