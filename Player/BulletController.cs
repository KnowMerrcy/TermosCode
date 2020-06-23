using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject impactEffect;
    public float speed;

    private Rigidbody2D bulletRb;


    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        if (collision.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
