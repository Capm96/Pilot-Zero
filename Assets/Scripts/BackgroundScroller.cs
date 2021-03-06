﻿using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Scrolls background image based on a variable input speed.

    [SerializeField] float backgroundScrollSpeed = 0.5f;

    Material myMaterial;
    Vector2 offSet;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime; // Makes scrolling speed frame-independent.
    }
}
