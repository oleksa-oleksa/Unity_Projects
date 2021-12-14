using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public int damage;

    Vector3 shootDirection;

    void Start()
    {
        
    }

    // 1
    void FixedUpdate()
    {
        // Moves the transform in the direction and distance of translation.
        this.transform.Translate(shootDirection * speed, Space.World);
    }

    // 2
    public void FireProjectile(Ray shootRay)
    {
        // A ray is an infinite line starting at origin and going in some direction.
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
        rotateInShootDirection();
    }

    // 3
    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

    void rotateInShootDirection()
    {
        // RotateTowards is very similar to MoveTowards, but it treats vectors as directions instead of positions.
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }
}
