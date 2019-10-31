using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float delay = 10;
    public float bulletSpeed = 10;
    private float cd = 0;
    private Vector3 target;
    public Camera camera;
    // Start is called before the first frame update
    public GameObject arrowPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = camera.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        if (cd == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(direction, rotationZ);
                cd = delay;
            }
        }
        else
        {
            cd -= 1;
        }
        

    }

    void Shoot(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, rotationZ)) as GameObject;
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
