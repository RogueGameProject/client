using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [SerializeField] private Camera sceneCamera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Weapon weapon;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

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

        if (Input.GetMouseButtonDown(0)) {
            weapon.Fire();
        }

        /*
            Every direction normalized, direction speed will not
            fluctuate under any circumstances 
        */
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    void Move() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
} 