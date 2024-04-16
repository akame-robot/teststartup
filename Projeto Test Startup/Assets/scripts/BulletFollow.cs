using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    public float seedVelocity;

    private Vector2 seedFollow;

    private int damage = 10;
    private int bossDamage = 20;

    // Start is called before the first frame update
    void Start()
    {
        seedFollow = GameObject.FindGameObjectWithTag("BulletDie").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, seedFollow, seedVelocity * Time.deltaTime);
        if ((Vector2)transform.position == seedFollow)
        {
            // Destruir a bala
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<BossEnemy>(out BossEnemy enemyComponent))
        {

            enemyComponent.TakeDamage(damage);
            Destroy(this.gameObject);

        }

        if (collision.gameObject.TryGetComponent<Boss>(out Boss bossComponent))
        {

            bossComponent.TakeDamage(bossDamage);
            Destroy(this.gameObject);

        }
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
