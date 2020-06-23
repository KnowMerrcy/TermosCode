using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawn : MonoBehaviour
{
    public GameObject star;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float delay;

    private float timer = 0.0f;
   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            float y = Random.Range(minY, maxY);
            float x = Random.Range(minX, maxX);
            Instantiate(star, new Vector3(x, y, 20), Quaternion.identity);
            timer = 0.0f;
        }
    }
}
