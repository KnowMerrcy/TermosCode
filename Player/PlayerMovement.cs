using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] playerPositions;

    private SwipeController swipe;
    private int lineMoveTo = 1;

    // Start is called before the first frame update
    void Start()
    {
        swipe = GetComponent<SwipeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swipe.SwipeUp)
        {
            Move(false);
        }

        if (swipe.SwipeDown)
        {
            Move(true);
        }

        transform.position = playerPositions[lineMoveTo].position;
    }

    private void Move(bool moveDown)
    {
        if (moveDown)
        {
            lineMoveTo++;
            if (lineMoveTo > 2)
            {
                lineMoveTo--;
            }
        }
        else
        {
            lineMoveTo--;
            if (lineMoveTo < 0)
            {
                lineMoveTo++;
            }
        }
    }
}
