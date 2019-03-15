using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;

    private Vector3 moveVec;

    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {

        if (transform.position.y < -2) {
            FindObjectOfType<GameManager>().GameOver();
        }

        if (Input.GetKey("escape")) {
            FindObjectOfType<GameManager>().GameOver();
        }

        float prevY = moveVec.y;
        moveVec = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveVec = moveVec.normalized * moveSpeed;
        moveVec.y = prevY + Physics.gravity.y * gravityScale;

        if (controller.isGrounded) {
            moveVec.y = 0f;
            if (Input.GetAxis("Jump") > 0f) {
                moveVec.y = jumpForce;
            }
        }

        controller.Move(moveVec * Time.deltaTime);
    }
}
