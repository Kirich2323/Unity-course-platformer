using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //private Rigidbody thisRB;
    
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale; //?

    private Vector3 moveVec;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        //thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //thisRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, thisRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        //moveVec = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveVec.y, Input.GetAxis("Vertical") * moveSpeed);

        float prevY = moveVec.y;
        moveVec = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveVec = moveVec.normalized * moveSpeed;
        moveVec.y = prevY;

        if (controller.isGrounded) {
            moveVec.y = 0f;
            if (Input.GetButtonDown("Jump")) {
                moveVec.y = jumpForce;
                //thisRB.velocity = new Vector3(thisRB.velocity.x, jumpForce, thisRB.velocity.z);
            }
        }

        moveVec.y += Physics.gravity.y * gravityScale;
        controller.Move(moveVec * Time.deltaTime);
    }
}
