using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public int jumpMaxTicks = 20;
    [SerializeField] private LayerMask platformLayerMask;
    int jumpTicks = 0;

    bool jumping = false;
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        //grounded if statements
        /*if(rb.velocity.y == 0 && !grounded && !Input.GetKey(KeyCode.Space))
        {
            groundCheck += 1;
        }
        if(groundCheck >= 1)
        {
            grounded = true;
            groundCheck = 0;
        }
        if(rb.velocity.y != 0)
        {
            grounded = false;
        }*/

        //jump
        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            jumping = true;
        }
        if(jumpTicks >= jumpMaxTicks || !Input.GetKey(KeyCode.Space))
        {
            jumping = false;
        }
        if(jumping && Input.GetKey(KeyCode.Space))
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
            jumpTicks += 1;
        }
        if (IsGrounded())
        {
            jumpTicks = 0;
        }
        
    }
    private bool IsGrounded()
    {
        float extra = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extra, platformLayerMask);
        return raycastHit.collider != null;
    }
   
}
