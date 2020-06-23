using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaTween : MonoBehaviour
{
    public float alpha;
    public float startingAlpha;
    public float time;

    private CanvasGroup background;

    private void OnEnable()
    {
        background = gameObject.GetComponent<CanvasGroup>();
        background.alpha = startingAlpha;
        LeanTween.alphaCanvas(background, alpha, time);
    }

    private void OnDisable()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = startingAlpha;
    }
}
