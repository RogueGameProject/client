using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 moveDirection;

    // Update is called once per frame
    // Processing Inputs
    void Update() {
        ProcessInputs();
    }

    // FixedUpdate is called a set amount of times per update move
    void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        // Strictly 0 or 1 for GetAxisRaw
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        /*
            Every direction normalized, direction speed will not
            fluctuate under any circumstances 
        */ 
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
