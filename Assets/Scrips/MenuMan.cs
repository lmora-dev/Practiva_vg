using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMan : MonoBehaviour
{

    AudioSource myAudio;
    public AudioClip buttonSound;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel(string lvl)
    {
        lvl = "lvltest";
        myAudio.PlayOneShot(buttonSound);
        SceneManager.LoadScene(lvl);
    }
}
