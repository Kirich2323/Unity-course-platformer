using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOverTime : MonoBehaviour {

    public float lifeTime = 0;
    void Update() {
        Destroy(gameObject, lifeTime);
    }
}
