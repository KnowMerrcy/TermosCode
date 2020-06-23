using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool isSwordBought;
    public bool isShieldBought;
    public bool isInfinityBought;
    public bool isGamePlayedFirstTime;
    public int playerCoins;
    public int highestScore;

    public GameData()
    {
        isSwordBought = GlobalVariables.isSwordBought;
        isShieldBought = GlobalVariables.isShieldBought;
        isInfinityBought = GlobalVariables.isInfinityBought;
        isGamePlayedFirstTime = GlobalVariables.isGamePlayedFirstTime;
        playerCoins = GlobalVariables.playerCoins;
        highestScore = GlobalVariables.highestScore;
    }
}
