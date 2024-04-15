using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup cavasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float timeToFade;
    private void Update()
    {
        if(fadeIn == true)
        {
            if (cavasGroup.alpha < 1)
            {
                cavasGroup.alpha += timeToFade * Time.deltaTime;
                if (cavasGroup .alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut == true)
        {
            if (cavasGroup.alpha >= 0)
            {
                cavasGroup.alpha -= timeToFade * Time.deltaTime;
                if (cavasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("BossStage");
        }
    }
}
