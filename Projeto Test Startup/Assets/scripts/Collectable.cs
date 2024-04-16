using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioClip somMorte;
    // Start is called before the first frame update
    void Start()
    {
        if (deathSound == null)
        {
            deathSound = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        CollectSound();
    }

    void CollectSound()
    {
        deathSound.PlayOneShot(somMorte);
    }
}
