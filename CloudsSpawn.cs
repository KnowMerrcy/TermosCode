using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawn : MonoBehaviour
{
    public GameObject[] clouds;
    public float minY;
    public float maxY;

    private float timer = 0.0f;
    private float delay = 2.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            float y = Random.Range(minY, maxY);
            int cloudID = Random.Range(0, clouds.Length);
            Instantiate(clouds[cloudID], new Vector3(12, y, 25), Quaternion.identity);
            timer = 0.0f;
        }
    }
}
