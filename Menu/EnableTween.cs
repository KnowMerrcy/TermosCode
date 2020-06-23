using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTween : MonoBehaviour
{
    public float duration;
    public LeanTweenType easeType;
    public Vector3 finalSize;


    private void OnEnable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, finalSize, duration).setEase(easeType);
    }
}
