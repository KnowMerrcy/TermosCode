using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public float deadZone = 100.0f;

    private bool tap, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;

    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }

    // Update is called once per frame
    void Update()
    {
        if (!EndGame.gameLost)
        {
            tap = swipeUp = swipeDown = false;

            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began && Camera.main.ScreenToWorldPoint(Input.touches[0].position).x < 0)
                {
                    tap = true;
                    isDraging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    Reset();
                }
            }

            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (Input.touches.Length > 0)
                {
                    swipeDelta = Input.touches[0].position - startTouch;
                }
            }

            if (swipeDelta.magnitude > deadZone)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;

                if (Mathf.Abs(y) > Mathf.Abs(x))
                {
                    if (y < 0)
                        swipeDown = true;
                    else
                        swipeUp = true;
                }
                Reset();
            }
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
