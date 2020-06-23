using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour
{
    public GameObject barrier;
    private ShootController shoot;

    // Start is called before the first frame update
    void Start()
    {
        shoot = gameObject.GetComponent<ShootController>();

        if (GlobalVariables.isShieldBought)
        {
            Instantiate(barrier, gameObject.transform.position - new Vector3(0.5f, 0.0f, -10.0f), Quaternion.identity);
            GlobalVariables.isShieldBought = false;
        }

        if (GlobalVariables.isSwordBought)
        {
            shoot.damage += 1;
            GlobalVariables.isSwordBought = false;
        }

        if (GlobalVariables.isInfinityBought)
        {
            shoot.delayBetweenShots /= 2;
            GlobalVariables.isInfinityBought = false;
        }
    }
}
