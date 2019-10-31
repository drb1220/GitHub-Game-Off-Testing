using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public GameObject particleSystemPrefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyScript enemyScript = other.collider.GetComponent<EnemyScript>();
        foreach (ContactPoint2D contact in other.contacts)
        {
            Instantiate(particleSystemPrefab, contact.point, Quaternion.identity);
        }
        if (enemyScript != null)
        {
            enemyScript.TakeDamage();
            gameObject.AddComponent<FixedJoint2D>();
            gameObject.GetComponent<FixedJoint2D>().connectedBody = other.rigidbody;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
