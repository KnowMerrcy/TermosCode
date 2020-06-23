using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static bool gameLost = false;
    public static int gamesPlayed = 0;

    public GameObject glasses;
    public GameObject gameOverScreen;
    public Text inGameScoreText;
    public Text endGameScoreText;
    public Text highestScoreText;
    public Text coinsText;

    

    private void Update()
    {
        if (!gameLost)
        {
            inGameScoreText.gameObject.SetActive(true);
        }
        else
        {
            inGameScoreText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            gamesPlayed++;
            if (gamesPlayed >= 3)
            {
                FindObjectOfType<AdController>().ShowVideoLost();
                gamesPlayed = 0;
            }
            gameOverScreen.gameObject.SetActive(true);
            gameLost = true;
            endGameScoreText.text = "Score: " + inGameScoreText.text;
            coinsText.text = "Coins: " + FindObjectOfType<CoinsPerGameCounter>().coinsPerGame;

            int score = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().score;

            if (score > GlobalVariables.highestScore)
            {
                GlobalVariables.highestScore = score;
            }

            highestScoreText.text = "Highest Score: " + GlobalVariables.highestScore;

            SaveLoadSystem.SaveData();

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Target"))
            {
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(glasses, enemy.transform, false);
            }
        }
    }
}
