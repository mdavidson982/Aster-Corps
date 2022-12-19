using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
    rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
    rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    //we also add a debug log to know what the projectile touch
    Debug.Log("Projectile Collision with " + other.gameObject);
    EnemyController e = other.collider.GetComponent<EnemyController>();
    if (e != null){
        e.ChangeHealth(5);
    }
    Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
