using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public int value = 1;
    public GameObject pickUpEffect;

    //public AudioSource audioSource;

    public AudioClip[] clips;


    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {
            FindObjectOfType<GameManager>().AddGold(value);

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();

            Instantiate(pickUpEffect, transform.position, transform.rotation);

            transform.Find("model").GetComponent<MeshRenderer>().enabled=false;
            Destroy(gameObject, 1);
        }
    }
}
