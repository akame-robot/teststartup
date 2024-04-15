using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    FadeInOut fade;

    public Button startGame;
    // Start is called before the first frame update
    void Start()
    {
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
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage1");
    }
}
