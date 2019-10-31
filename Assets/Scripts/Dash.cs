using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Vector3 target;
    public Camera camera;
    public float dashSpeed = 10;
    public float ticks = 5;
    private float timer = 0;
    private float gstemp;
    private bool dashed = false;
    PlayerMovement p;
    Rigidbody2D rb;
    [SerializeField] private LayerMask platformLayerMask;
    public PhysicsMaterial2D playerMaterial;
    BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        gstemp = rb.gravityScale;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGrounded())
        {
            dashed = false;
        }
        target = camera.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        if (Input.GetKeyDown(KeyCode.LeftControl) && !dashed)
        {
            DashAction(rotationZ);
        }
        if(timer > 0 && timer < ticks)
        {
            timer += 1;
        }else if(timer == ticks)
        {
            rb.gravityScale = gstemp;
            timer = 0;
            p.enabled = true;

            

            rb.velocity = new Vector2(0,0);
        }
        
        
        
    }
    
    void DashAction(float rotationZ)
    {
        Vector2 d = new Vector2(Mathf.Cos(rotationZ) * dashSpeed, Mathf.Sin(rotationZ) * dashSpeed);
        rb.velocity = d;
        timer = 1;
        rb.gravityScale = 0;
        p.enabled = false;

      

        dashed = true;
    }

    private bool IsGrounded()
    {
        float extra = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extra, platformLayerMask);
        return raycastHit.collider != null;
    }
}
