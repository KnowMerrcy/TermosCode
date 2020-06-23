using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenController : MonoBehaviour
{
    public Button continueButton;
    public Text countdownText;
    public Button doubleCoinButton;
    public Animator transitionAnim;

    private void Start()
    {
        doubleCoinButton.interactable = true;
    }

    public void ContinueGame()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(target);
        }

        continueButton.interactable = false;
        EndGame.gamesPlayed--;
        countdownText.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        EndGame.gameLost = false;
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(target);
        }
        StartCoroutine(LoadGame(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EndGame.gameLost = false;
    }

    public void PressButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
    }

    private IEnumerator LoadGame(int sceneIndex)
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene(sceneIndex);
    }
}
