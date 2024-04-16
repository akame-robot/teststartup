using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player, canvas, canvas2;
    public float playerVelocity, jumpForce;
    public float gravityForce;
    public bool isGround = true;
    public GameObject cannon;
    public GameObject bulletOut;
    public GameObject bullets;

    public GameObject gear1, gear2, gear3, gear4, gear5;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
 
    }

    public void PlayerMove()
    {
        if (cannon != null && Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullets, bulletOut.transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(new Vector2(-1, 0) * playerVelocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(new Vector2(1, 0) * playerVelocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            isGround = false;
        }
        rb.AddForce(new Vector3(0, -gravityForce, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BossBullets"))
        {
            canvas.SetActive(true);
            canvas2.SetActive(false);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Gear1"))
        {
            gear1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Gear2"))
        {
            gear2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Gear3"))
        {
            gear3.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Gear4"))
        {
            gear4.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Gear5"))
        {
            gear5.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            //// Verifica se o jogador está acima do inimigo para matá-lo
            //if (transform.position.y > collision.transform.position.y)
            //{
            //    Destroy(collision.gameObject);
            //}
            //else
            //{
            //    canvas.SetActive(true);
            //    Jogador morre
            //    Destroy(gameObject);
            //    Aqui você pode adicionar lógica para reiniciar o jogo ou mostrar tela de game over
            //}
            if (transform.position.y < collision.transform.position.y)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Ground2"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("death"))
        {
            canvas.SetActive(true);
            Destroy(this.gameObject);
        }


    }
}
