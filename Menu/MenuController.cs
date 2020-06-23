using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject creditsScreen;
    public GameObject shopScreen;
    public GameObject rateButton;
    public GameObject rateText;
    public Animator transitionAnim;

    // Start is called before the first frame update
    void Awake()
    {
        GameData data = SaveLoadSystem.LoadData();

        if (data != null)
        {
            GlobalVariables.isShieldBought = data.isShieldBought;
            GlobalVariables.isSwordBought = data.isSwordBought;
            GlobalVariables.isInfinityBought = data.isInfinityBought;
            GlobalVariables.playerCoins = data.playerCoins;
            GlobalVariables.highestScore = data.highestScore;
            GlobalVariables.isGamePlayedFirstTime = data.isGamePlayedFirstTime;
        }

        menuScreen.SetActive(true);
        rateButton.SetActive(true);
        rateText.SetActive(true);
        creditsScreen.SetActive(false);
        shopScreen.SetActive(false);
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        StartCoroutine(LoadGame(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void EnableShop()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        menuScreen.SetActive(false);
        rateButton.SetActive(false);
        rateText.SetActive(false);
        shopScreen.SetActive(true);
    }

    public void EnableCredits()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        menuScreen.SetActive(false);
        rateButton.SetActive(false);
        rateText.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void EnableMenu()
    {
        FindObjectOfType<AudioManager>().Play("PressButton");
        menuScreen.SetActive(true);
        rateButton.SetActive(true);
        rateText.SetActive(true);
        creditsScreen.SetActive(false);
        shopScreen.SetActive(false);
    }

    private IEnumerator LoadGame(int sceneIndex)
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene(sceneIndex);
    }
}
