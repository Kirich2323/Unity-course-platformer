using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Debug.Log("Playef fell");
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
