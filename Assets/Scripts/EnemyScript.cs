using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 3;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void TakeDamage()
    {
        rb.velocity = new Vector2(0, 0);
        health -= 1;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Health healthScript = other.collider.GetComponent<Health>();
        if (healthScript != null)
        {
            healthScript.Damage(1);
        }
    }
}
