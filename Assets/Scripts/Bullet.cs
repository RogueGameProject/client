using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D other) {
        // Object collider and null check
        if (other != null) {
            switch (other.gameObject.tag) {
                case "Wall":
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
