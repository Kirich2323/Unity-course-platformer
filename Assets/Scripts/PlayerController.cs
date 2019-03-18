using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public TextMeshProUGUI speedText;
    //public float gravityScale;

    public float maxSpeed;

    public Transform pivot;

    private Vector3 moveVec;
    private float GroundDistance = 0.5f;

    //private CharacterController controller;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, GroundDistance + 0.3f);
    }

    void FixedUpdate() {

        /*if (transform.position.y < -2) {
            FindObjectOfType<GameManager>().GameOver();
        }*/

        if (Input.GetKey("escape")) {
            FindObjectOfType<GameManager>().GameOver();
        }

        var vert = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");
        var jmp = Input.GetAxis("Jump");

        Vector3 clampled = Vector3.ClampMagnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z), maxSpeed);
        speedText.text = "Speed: " + clampled.magnitude.ToString() + " units";


        if (vert == 0 && hor == 0 && jmp == 0) {
            return;
        }

        moveVec.x = rb.velocity.x;
        moveVec.z = rb.velocity.z;

        var hit = new RaycastHit();
        Physics.Raycast(new Ray(transform.position, -Vector3.up), out hit, GroundDistance + 0.3f);
        Vector3 forward = pivot.forward;
        Vector3 right = pivot.right;

        float speed = moveSpeed;
        Vector3 jumpVec = new Vector3(0f, rb.velocity.y, 0f);

        clampled.y = rb.velocity.y;
        rb.velocity = clampled;

        

        if (IsGrounded()) {
            forward = Vector3.Cross(hit.normal, -pivot.right);
            right = Vector3.Cross(hit.normal, pivot.forward);

            if (jmp > 0f) {
                jumpVec += hit.normal * jumpForce;
            }

            moveVec = (forward * vert) + (right * hor);
            moveVec = moveVec.normalized * speed;
            moveVec += jumpVec;
            //rb.velocity = new Vector3(moveVec.x, moveVec.y, moveVec.z);
            //rb.MovePosition(transform.position + new Vector3(moveVec.x, moveVec.y, moveVec.z) * Time.deltaTime);
            rb.AddForce(new Vector3(moveVec.x, moveVec.y, moveVec.z));
            //rb.AddTorque(new Vector3(moveVec.x, moveVec.y, moveVec.z));
        }
        else {
            speed = moveSpeed / 2f;
            moveVec = (forward * vert) + (right * hor);
            moveVec = moveVec.normalized * speed;
            rb.AddForce(moveVec);
        }
        
        
        //moveVec.y += up;


    }
}
