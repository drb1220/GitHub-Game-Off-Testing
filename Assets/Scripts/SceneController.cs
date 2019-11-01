using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;
    int dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
    }

    public void Right()
    {
        StartCoroutine(RightC());
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(dir, 0f, 0f);
        transform.position += movement * 12 * Time.deltaTime;
    }

    IEnumerator RightC()
    {
        pm.enabled = false;
        dir = 1;
        yield return new WaitForSeconds(1f);
        dir = 0;
        pm.enabled = true;
    }
}
