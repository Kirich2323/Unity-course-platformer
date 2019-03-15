using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;

    public float rotationSpeed;
    public Vector3 offset;
    public bool useProvidedOffset;
    public Transform pivot;

    // Start is called before the first frame update
    void Start() {
        if (!useProvidedOffset) {
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate() {
        if (Cursor.lockState != CursorLockMode.Locked) {
            return; // ? hack?
        }
        var rotationY = Input.GetAxis("Mouse X") * rotationSpeed;
        var rotationX = Input.GetAxis("Mouse Y") * rotationSpeed;
        target.Rotate(0f, rotationY, 0f);
        pivot.Rotate(-rotationX, 0f, 0f);

        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180) {
            pivot.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 315f) {
            pivot.rotation = Quaternion.Euler(315f, 0, 0);
        }

        float angleY = target.eulerAngles.y;
        float angleX = pivot.eulerAngles.x;

        Quaternion quatRotation = Quaternion.Euler(angleX, angleY, 0f);
        transform.position = target.position - (quatRotation * offset);

        if (transform.position.y < target.position.y) {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.2f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
