using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoughtSignController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableShieldBoughtSign()
    {
        gameObject.SetActive(GlobalVariables.isShieldBought);
    }

    public void EnableSwordBoughtSign()
    {
        gameObject.SetActive(GlobalVariables.isSwordBought);
    }

    public void EnableInfinityBoughtSign()
    {
        gameObject.SetActive(GlobalVariables.isInfinityBought);
    }

}
