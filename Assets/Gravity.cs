using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody2D rb;
    public float GravityCap = 10;
    public float GravitySpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.y > -1*GravityCap)
        {
            rb.velocity -= new Vector2(0, GravitySpeed);
        }
        
    }
}
