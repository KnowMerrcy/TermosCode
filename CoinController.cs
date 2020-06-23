using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float soundVolume;

    private AudioSource coinSound;

    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
