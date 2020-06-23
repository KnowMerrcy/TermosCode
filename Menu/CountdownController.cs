using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    private float counter = 3.0f;
    private bool gameContinued = false;
    private Text countdownText;

    void OnEnable()
    {
        StartCoroutine("Countdown");
        countdownText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameContinued)
        {
            countdownText.text = Mathf.Round(counter).ToString();
            counter -= Time.deltaTime;
        }
    }

    IEnumerator Countdown()
    {
        gameContinued = true;
        yield return new WaitForSeconds(3);
        EndGame.gameLost = false;
        countdownText.gameObject.SetActive(false);
        gameContinued = false;
    }
}
