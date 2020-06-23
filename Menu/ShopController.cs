using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text priceText;
    public GameObject descriptionWindow;
    public Text coinsText;
    public int powerUpPrice;
    public GameObject boughtSign;
    public GameObject firstSide;

    public float finalSizeX;
    public float time;

    private void Start()
    {
        coinsText.text = GlobalVariables.playerCoins.ToString();
        priceText.text = powerUpPrice.ToString();
    }

    private void OnEnable()
    {
        ShowFirstSide();
    }

    private void ShowSecondSide()
    {
        firstSide.SetActive(false);
        descriptionWindow.SetActive(true);
    }

    private void ShowFirstSide()
    {
        descriptionWindow.SetActive(false);
        firstSide.SetActive(true);
    }

    public void ShowDescription(bool show)
    {
        if (show)
        {
            FindObjectOfType<AudioManager>().Play("PressButton");
            LeanTween.scaleX(gameObject, 0.0f, time).setOnComplete(ShowSecondSide);
            LeanTween.scaleX(gameObject, finalSizeX, time).setDelay(time + 0.05f);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("PressButton");
            LeanTween.scaleX(gameObject, 0.0f, time).setOnComplete(ShowFirstSide);
            LeanTween.scaleX(gameObject, finalSizeX, time).setDelay(time + 0.05f);
        }
    }

    public void BuyShieldPowerUp()
    {
        if (GlobalVariables.playerCoins >= powerUpPrice)
        {
            if (!GlobalVariables.isShieldBought)
            {
                FindObjectOfType<AudioManager>().Play("BuyPowerUp");
                GlobalVariables.isShieldBought = true;
                GlobalVariables.playerCoins -= powerUpPrice;
                coinsText.text = GlobalVariables.playerCoins.ToString();
                boughtSign.SetActive(true);
                SaveLoadSystem.SaveData();
            }
        }
        else
        {
            coinsText.GetComponent<Animation>().Play("NotEnoughCoins");
            FindObjectOfType<AudioManager>().Play("NotEnoughCoins");
        }
    }

    public void BuySwordPowerUp()
    {
        if (GlobalVariables.playerCoins >= powerUpPrice)
        {
            if (!GlobalVariables.isSwordBought)
            {
                FindObjectOfType<AudioManager>().Play("BuyPowerUp");
                GlobalVariables.isSwordBought = true;
                GlobalVariables.playerCoins -= powerUpPrice;
                coinsText.text = GlobalVariables.playerCoins.ToString();
                boughtSign.SetActive(true);
                SaveLoadSystem.SaveData();
            }
        }
        else
        {
            coinsText.GetComponent<Animation>().Play("NotEnoughCoins");
            FindObjectOfType<AudioManager>().Play("NotEnoughCoins");
        }
    }

    public void BuyInfinityPowerUp()
    {
        if (GlobalVariables.playerCoins >= powerUpPrice)
        {
            if (!GlobalVariables.isInfinityBought)
            {
                FindObjectOfType<AudioManager>().Play("BuyPowerUp");
                GlobalVariables.isInfinityBought = true;
                GlobalVariables.playerCoins -= powerUpPrice;
                coinsText.text = GlobalVariables.playerCoins.ToString();
                boughtSign.SetActive(true);
                SaveLoadSystem.SaveData();
            }
        }
        else
        {
            coinsText.GetComponent<Animation>().Play("NotEnoughCoins");
            FindObjectOfType<AudioManager>().Play("NotEnoughCoins");
        }
    }
}
