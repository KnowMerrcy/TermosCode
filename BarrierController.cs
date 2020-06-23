using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public GameObject destroyEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            Instantiate(destroyEffect, transform.position, destroyEffect.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
