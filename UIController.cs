﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public int score;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
