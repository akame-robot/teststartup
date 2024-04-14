using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    public float seedVelocity;

    private Vector2 seedFollow;

    // Start is called before the first frame update
    void Start()
    {
        seedFollow = GameObject.FindGameObjectWithTag("BulletDie").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, seedFollow, seedVelocity * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("boss"))
        {
            Destroy(this.gameObject);
        }
    }
}
