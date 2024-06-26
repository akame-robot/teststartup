using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private float velocity;
    private int life; 
    private int fullLife;
    public AudioSource deathSound;
    public AudioClip somMorte;
    // Start is called before the first frame update
    void Start()
    {
        if (deathSound == null)
        {
            deathSound = GetComponent<AudioSource>();
        }
        life = Random.Range(25, 35);
        fullLife = life;
        velocity = Random.Range(6.5f, 14f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-velocity * Time.deltaTime, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        //aqui onde tudo come�a para tomar dano
        fullLife -= damage;
        DeathSound();


        //se a vida for igual a 0 vai destruir o objeto
        if (fullLife <= 0)
        {
            DeathSound();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DeathSound();
            Destroy(this.gameObject);
        }
    }

    void DeathSound()
    {
        deathSound.PlayOneShot(somMorte);
    }
}
