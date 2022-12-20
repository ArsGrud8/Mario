using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int count;
    public AudioClip audioClip;

    private GameObject player;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<PlayerControler>().AddCoin(count);
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }

}
