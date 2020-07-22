using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool gameOver = false;
    public CanvasGroup gameOverPanel;
    public float alphaRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        
    }

    public void GameOver()
    {
        if (gameOver)
        {
            gameOverPanel.alpha += alphaRate * Time.deltaTime;

            if (gameOverPanel.alpha >=1){
                gameOverPanel.alpha = 1;
                gameOverPanel.blocksRaycasts = true;
            }
        }

    }

    public void RetryLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }
}
