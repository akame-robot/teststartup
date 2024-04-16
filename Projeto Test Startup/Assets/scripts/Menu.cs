using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    FadeInOut fade;

    public AudioSource audioSource; // Referência ao componente AudioSource
    public AudioClip som;

    public Button startGame;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        fade = GetComponent<FadeInOut>();
        startGame.onClick.AddListener(GameScene);

        void GameScene()
        {
            StartCoroutine(ChangeScene());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        audioSource.PlayOneShot(som);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage1");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
