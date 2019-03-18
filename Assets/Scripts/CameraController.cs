using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;

    public float rotationSpeed;
    public Vector3 offset;
    public bool useProvidedOffset;
    public Transform pivot;

    private GameObject rotationPivot;
    private float offsetAngleY;
    private float offsetAngleX;

    void Start() {
        if (!useProvidedOffset) {
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotationPivot = new GameObject();
        pivot.parent = null;

        transform.LookAt(target);
        Debug.Log(pivot.transform.rotation.eulerAngles);
        offsetAngleY = transform.rotation.eulerAngles.y;
        offsetAngleX = transform.rotation.eulerAngles.x;
        //pivot.Rotate(0f, offsetAngleY, 0f);
        pivot.transform.rotation = Quaternion.Euler(0f, offsetAngleY, 0f);
        rotationPivot.transform.rotation = Quaternion.Euler(-offsetAngleX, 0f, 0f);
        Debug.Log(pivot.transform.rotation.eulerAngles);
    }

    void LateUpdate() {
        if (Cursor.lockState != CursorLockMode.Locked) {
            return; // ? hack?
        }
        
        pivot.position = target.position;
        rotationPivot.transform.position = target.position;

        var rotationY = Input.GetAxis("Mouse X") * rotationSpeed;
        var rotationX = Input.GetAxis("Mouse Y") * rotationSpeed;
        pivot.Rotate(0f, rotationY, 0f);
        rotationPivot.transform.Rotate(-rotationX, 0f, 0f);

        Vector3 anlges = rotationPivot.transform.rotation.eulerAngles;
        if (anlges.x > 45f && anlges.x < 180) {
            rotationPivot.transform.rotation = Quaternion.Euler(45f, 0, 0);
        }

        if (anlges.x > 180f && anlges.x < 315f) {
            rotationPivot.transform.rotation = Quaternion.Euler(315f, 0, 0);
        }

        float angleY = pivot.eulerAngles.y - offsetAngleY;
        float angleX = rotationPivot.transform.eulerAngles.x - offsetAngleX;

        Quaternion quatRotation = Quaternion.Euler(angleX, angleY, 0f);
        transform.position = target.position - (quatRotation * offset);

        if (transform.position.y < target.position.y) {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.2f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
