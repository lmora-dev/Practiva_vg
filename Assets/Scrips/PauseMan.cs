using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMan : MonoBehaviour
{

    bool isPaused = false;
    AudioSource myAudio;
    public AudioClip pauseIN;
    public AudioClip pauseOUT;

    public GameObject PausePanel;


    void Start()
    {

        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause_Game();
        }

    }

    public void Pause_Game()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            myAudio.PlayOneShot(pauseIN);

        }
        else
        {
            Time.timeScale = 1;
            myAudio.PlayOneShot(pauseOUT);
            PausePanel.SetActive(false);

        }
    }

    public void Puased()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        myAudio.PlayOneShot(pauseIN);

    }

    public void Resume()
    {
        Time.timeScale = 1;
        myAudio.PlayOneShot(pauseOUT);
        PausePanel.SetActive(false);

    }

    public void Menu(string menu)
    {
        menu = "Menu";
        Resume();
        SceneManager.LoadScene(menu);
    }




}
