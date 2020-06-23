using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public float delayBetweenShots = 1.0f;
    public int damage = 1;

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (!EndGame.gameLost)
        {
            if (timer >= delayBetweenShots)
            {
                Instantiate(bullet, shootPoint.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("Shoot");
                timer = 0.0f;
            }
        }
    }
}
