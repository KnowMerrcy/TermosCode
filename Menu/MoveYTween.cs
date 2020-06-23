using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYTween : MonoBehaviour
{
    public float moveToY;
    public float time;
    public float startingY;

    private void OnDisable()
    {
        transform.localPosition = new Vector3(gameObject.transform.localPosition.x, startingY, gameObject.transform.localPosition.z);
    }

    private void OnEnable()
    {
        LeanTween.moveLocalY(gameObject, moveToY, time);
    }
}
