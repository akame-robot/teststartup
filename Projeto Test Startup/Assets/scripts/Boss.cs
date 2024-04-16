using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private HealthBar healthBar;
    private int life = 1000;
    public GameObject message, message2, bossName;

    public int fullLife;

    private bool invoking = true;

    public GameObject enemy, enemySpawn;
    public GameObject respawn;


    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {

        healthBar.UpdateHealthBar(life, fullLife);
        fullLife = life;
        StartCoroutine(Spawnenemy());
    }
    private void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        //aqui onde tudo começa para tomar dano
        fullLife -= damage;
        healthBar.UpdateHealthBar(fullLife, damage);
       


        //se a vida for igual a 0 vai destruir o objeto
        if (fullLife <= 0)
        {
            message2.SetActive(false);
            message.SetActive(true);
            respawn.SetActive(true);
            bossName.SetActive(false);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullets"))
    //    {
    //        fullLife -= 20;
    //        healthBar.UpdateHealth(life, fullLife);
    //    }
    //}

    IEnumerator Spawnenemy()
    {
        while (invoking)
        {
            yield return new WaitForSeconds(Random.Range(1, 2.8f));
            Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
        }

    }
}
