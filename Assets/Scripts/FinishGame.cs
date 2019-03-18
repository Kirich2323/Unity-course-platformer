using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //Debug.Log("Playef fell");
            FindObjectOfType<GameManager>().Finish();
        }
    }
}
