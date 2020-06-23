using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float speed = 5.0f;
    public int HP = 1;
    public int score = 10;
    public long vibrationMiliseconds;
    public GameObject targetDestroyEffect;
    public GameObject barrierDestroyEffect;
    public AnimationClip hitAnimation;

    private float rotationSpeed = 100.0f;
    private float z = 0.0f;
    private UIController UI;
    private ShootController shoot;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!EndGame.gameLost)
        {
            Vector3 moveDirection = new Vector3(transform.position.x - 30.0f, transform.position.y, transform.position.z);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, step);


            z -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (gameObject.tag == "Coin")
            {
                GlobalVariables.playerCoins++;
                FindObjectOfType<AudioManager>().Play("Coin");
                FindObjectOfType<CoinsPerGameCounter>().coinsPerGame++;
            }

            HP -= shoot.damage;

            if (HP <= 0)
            {
                UI.score += score;
                Instantiate(targetDestroyEffect, transform.position, targetDestroyEffect.transform.rotation);
                if (gameObject.tag != "Coin")
                {
                    FindObjectOfType<AudioManager>().Play("FruitHit");
                }
                Vibration.Vibrate(vibrationMiliseconds);
                Destroy(gameObject);
            }
            else
            {
                if (GetComponent<Animation>() != null)
                {
                    Animation anim = GetComponent<Animation>();
                    anim.AddClip(hitAnimation, "hit");
                    anim.Play("hit");
                }
            }

        }

        if (collision.tag == "Barrier" && gameObject.tag != "Coin")
        {
            Instantiate(targetDestroyEffect, transform.position, targetDestroyEffect.transform.rotation);
            Instantiate(barrierDestroyEffect, collision.transform.position, barrierDestroyEffect.transform.rotation);
            FindObjectOfType<AudioManager>().Play("Barrier");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
