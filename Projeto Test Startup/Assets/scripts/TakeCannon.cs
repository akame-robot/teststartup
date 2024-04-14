using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCannon : MonoBehaviour
{
    public GameObject cannon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cannon.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
