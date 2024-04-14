using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    public float Gravity;
    private Rigidbody2D rb;
    private float timeToFall = 10;
    private float timeRunning = 0;
    public bool playerOn = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerOn)
        {
            timeRunning += Time.deltaTime;

            if (timeRunning >= timeToFall)
            {
                rb.AddForce(new Vector3(0, -Gravity, 0));
                Destroy(this.gameObject, 10);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;         
        }
    }
}
