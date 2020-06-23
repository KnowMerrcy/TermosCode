using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPerGameCounter : MonoBehaviour
{
    public int coinsPerGame;

    // Start is called before the first frame update
    void Start()
    {
        coinsPerGame = 0;
    }

    private void Update()
    {
        if (EndGame.gameLost)
        {
            FindObjectOfType<AdController>().tripleCoinsReward = coinsPerGame;
        }
    }
}
