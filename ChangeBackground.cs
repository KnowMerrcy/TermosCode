using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public float speed;
    public float dayTime;

    private SpriteRenderer spriteRenderer;
    private float timer = 0.0f;
    private float rgb = 255f;
    private bool isDay;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        isDay = true;
        spriteRenderer.color = new Color32((byte)rgb, (byte)rgb, (byte)rgb, 255);
        FindObjectOfType<CloudsSpawn>().enabled = true;
        FindObjectOfType<StarsSpawn>().enabled = false;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= dayTime)
        {
            if (isDay)
            {
                if (rgb >= 65)
                {
                    rgb -= Time.deltaTime * speed;

                    spriteRenderer.color = new Color32((byte)rgb, (byte)rgb, (byte)rgb, 255);
                }
                else
                {
                    timer = 0.0f;
                    isDay = false;
                }

                if (rgb <= 130)
                {
                    FindObjectOfType<CloudsSpawn>().enabled = false;
                    FindObjectOfType<StarsSpawn>().enabled = true;
                }
            }

            if (!isDay)
            {
                if (rgb <= 255)
                {
                    rgb += Time.deltaTime * speed;

                    spriteRenderer.color = new Color32((byte)rgb, (byte)rgb, (byte)rgb, 255);
                } 
                else
                {
                    timer = 0.0f;
                    isDay = true;
                }

                if (rgb >= 180)
                {
                    FindObjectOfType<CloudsSpawn>().enabled = true;
                    FindObjectOfType<StarsSpawn>().enabled = false;
                }
            }
        }
    }
}
