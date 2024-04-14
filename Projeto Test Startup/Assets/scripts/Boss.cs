using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int life = 400;
    public GameObject message;
    private bool isDelay = false;
    public float delayTime = 1.5f;
    private float delayTimer = 0f;
    public int fullLife;


    // Start is called before the first frame update
    void Start()
    {
        fullLife = life;
    }

    // Update is called once per frame
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            fullLife -= 20;
        }
        if(fullLife == 0)
        {
            message.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
