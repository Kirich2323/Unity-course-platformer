using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed;
    public Vector3 offset;
    public bool useProvidedOffset;
    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        if (!useProvidedOffset) {
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rotationY = Input.GetAxis("Mouse X") * rotationSpeed;
        var rotationX = Input.GetAxis("Mouse Y") * rotationSpeed;
        target.Rotate(0f, rotationY, 0f);
        pivot.Rotate(-rotationX, 0f, 0f);

        float angleY = target.eulerAngles.y;
        float angleX = pivot.eulerAngles.x;

        Quaternion quatRotation = Quaternion.Euler(angleX, angleY, 0f);
        transform.position = target.position - (quatRotation * offset);

        //transform.position = target.position - offset;

        transform.LookAt(target);
    }
}
