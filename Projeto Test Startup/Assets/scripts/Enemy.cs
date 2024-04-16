using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform[] patrolPoints;
    private int currentPatrolPointIndex = 0;
    private Rigidbody2D rb;
    private bool isDead = false;
    public GameObject iten;

    public AudioSource deathSound;
    public AudioClip somMorte;



    void Start()
    {
        if (deathSound == null)
        {
            deathSound = GetComponent<AudioSource>();
        }
        rb = GetComponent<Rigidbody2D>();
        // Inicialmente, o inimigo se move para o primeiro ponto de patrulha
        MoveToNextPatrolPoint();
    }

    void Update()
    {
        // Movimenta o inimigo na direção do ponto de patrulha atual
        if (!isDead)
        {
            Vector2 direction = (patrolPoints[currentPatrolPointIndex].position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // Se chegarmos ao ponto de patrulha, passamos para o próximo
            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position) < 0.1f)
            {
                MoveToNextPatrolPoint();
            }
        }
    }

    void MoveToNextPatrolPoint()
    {
        // Incrementa o índice para o próximo ponto de patrulha ou reinicia se chegarmos ao final
        currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position.y < collision.transform.position.y)
        {
            Vector3 localScale = new Vector3(1, -0.5f, 1);
            transform.localScale = localScale;
            DeathSound();
            Destroy(this.gameObject,1);
            GetComponent<Collider>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Bullets"))
        {
            Destroy(this.gameObject);
        }
    }

    void DeathSound()
    {
        deathSound.PlayOneShot(somMorte);
    }
}
