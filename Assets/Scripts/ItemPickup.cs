using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public int value = 1;
    public GameObject pickUpEffect;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            FindObjectOfType<GameManager>().AddGold(value);
            Destroy(gameObject);

            Instantiate(pickUpEffect, transform.position, transform.rotation);
        }
    }
}
