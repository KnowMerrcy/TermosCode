using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdController : MonoBehaviour, IUnityAdsListener
{
    public static AdController instance;
    public int tripleCoinsReward;
    public int shopCoinsReward;

    private string rewardedPlacementId = "rewardedVideo";
    private string videoPlacementId = "video";
    private string rewardedTripleCoinsPlacementId = "rewardedVideoDoubleCoins";
    private string videoLostPlacementId = "videoLost";
    private string gameId = "3544707";

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(rewardedPlacementId))
        {
            Advertisement.Show(rewardedPlacementId);
        }
        else
        {
            return;
        }
    }

    public void ShowRewardedVideoDoubleCoins()
    {
        if (Advertisement.IsReady(rewardedTripleCoinsPlacementId))
        {
            Advertisement.Show(rewardedTripleCoinsPlacementId);
        }
        else
        {
            return;
        }
    }

    public void ShowVideo()
    {
        if (Advertisement.IsReady(videoPlacementId))
        {
            Advertisement.Show(videoPlacementId);
        }
        else
        {
            return;
        }
    }

    public void ShowVideoLost()
    {
        if (Advertisement.IsReady(videoLostPlacementId))
        {
            Advertisement.Show(videoLostPlacementId);
        }
        else
        {
            return;
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (placementId == rewardedPlacementId)
            {
                GlobalVariables.playerCoins += shopCoinsReward;
                SaveLoadSystem.SaveData();
                GameObject.Find("PlayerCoinsText").GetComponent<Text>().text = GlobalVariables.playerCoins.ToString();

            }
            else if (placementId == videoPlacementId)
            {
                FindObjectOfType<GameOverScreenController>().ContinueGame();
            }
            else if (placementId == rewardedTripleCoinsPlacementId)
            {
                GlobalVariables.playerCoins += tripleCoinsReward*2;
                SaveLoadSystem.SaveData();
                GameObject.Find("CoinsText").GetComponent<Text>().text = "Coins: " + tripleCoinsReward * 3;
                FindObjectOfType<CoinsPerGameCounter>().coinsPerGame += tripleCoinsReward * 2; ;
            }
            else if (placementId == videoLostPlacementId)
            {

            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            if (placementId == videoPlacementId)
            {
                FindObjectOfType<GameOverScreenController>().ContinueGame();
            }
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }

        FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().volume = 0.35f;
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {
        FindObjectOfType<AudioManager>().gameObject.GetComponent<AudioSource>().volume = 0;
    }
}
