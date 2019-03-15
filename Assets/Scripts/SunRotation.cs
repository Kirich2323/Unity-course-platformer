using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour {
    public float rotationSpeed = 1;
    public float speedUpScale = 10;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float scale = 1;
        if (transform.rotation.eulerAngles.x > 180f) {
            scale = speedUpScale;
        }
        gameObject.transform.Rotate(scale * rotationSpeed * Time.deltaTime, 0, 0);
    }
}
