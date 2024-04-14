using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float playerVelocity, jumpForce;
    public float gravityForce;
    public bool isGround = true;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Verifica se o jogador está acima do inimigo para matá-lo
            if (transform.position.y > collision.transform.position.y)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                // Jogador morre
                Destroy(gameObject);
                // Aqui você pode adicionar lógica para reiniciar o jogo ou mostrar tela de game over
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("death"))
        {
            Destroy(this.gameObject);
        }
    }
}
