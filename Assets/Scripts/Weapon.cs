using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;
    public void Fire() {
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        // Ensures that the RigidBody2D is present on the instantiated object
        if (projectile.TryGetComponent(out Rigidbody2D projectileRB)) {
            projectileRB.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        }
        // projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}