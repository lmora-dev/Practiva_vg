using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtMan : MonoBehaviour
{
    //public int health = 1;
    //public int lifes = 3;
    int currentHealth;

    bool PlayerHurt = false;
    Vector3 orginalPosition;

    [HideInInspector]
    public float shakeAmout = 2.5f;
    [HideInInspector]
    public float dealayForReset = 3.2f;
    
    //public float shakeDuration = 0.2f;

    

    Animator playerAnim;
    BeginManager begin;
    public Transform spawnPoint;
    Player_Controller pc;
    Rigidbody2D rb;
    public GameObject transitionScren;
    AudioSource myAudio;
    public AudioClip deadSound;
    LevelManager lvlManager;

    public Player DatosPlayer;
    private int health;
    private int lifes;
    private float shakeDuration;

    void Start()
    {
        health = DatosPlayer.Salud;
        lifes = DatosPlayer.Vidas;
        shakeDuration = DatosPlayer.StunDanno;

        currentHealth = health;
        playerAnim = GetComponent<Animator>();
        pc = GetComponent<Player_Controller>();
        begin = GameObject.FindGameObjectWithTag("GameController").GetComponent<BeginManager>();
        lvlManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
        rb = GetComponent<Rigidbody2D>();
        begin.UpdateLifes(lifes);
        myAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHurt)
        {
            Vector3 newPos = orginalPosition + Random.insideUnitSphere * (Time.deltaTime * shakeAmout);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy_bullet") || col.CompareTag("Enemy") || col.CompareTag("KillZone") )
        {
            currentHealth--;
            orginalPosition = transform.position;
            PlayerHurt = true;
            playerAnim.SetBool("hurt", PlayerHurt);
            pc.canMove = false;

            if (col.CompareTag("Enemy_bullet"))
            {
                Destroy(col.gameObject);
            }

            
            if (currentHealth <= 0)
            {
                lifes--;
                myAudio.PlayOneShot(deadSound);
                gameObject.layer = 11;
                playerAnim.SetBool("ded", true);
                rb.velocity = Vector2.zero;
                pc.canMove = false;


                if (lifes <= 0)
                {
                    lifes = 0;
                    lvlManager.gameOver = true;
                    return;

                }

               StartCoroutine(ResetPlayer());

            }
            StartCoroutine(PlayerShaking());

        }

    }

    


    IEnumerator PlayerShaking()
    {
        yield return new WaitForSeconds(shakeDuration);

        PlayerHurt = false;

        if (currentHealth > 0)
        {

            pc.canMove = true;
        }

        playerAnim.SetBool("hurt", false);
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(1f);
        transitionScren.GetComponent<Animator>().Play("transition");

        yield return new WaitForSeconds(dealayForReset);
        currentHealth = health;
 
        begin.UpdateLifes(lifes);
        transform.position = spawnPoint.position;
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        playerAnim.SetBool("ded", false);
        playerAnim.SetBool("shooting", false);
        gameObject.layer = 10;

        transitionScren.GetComponent<Animator>().Play("transition_close");

        float delay = transitionScren.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(delay - 1);
        pc.canMove = true;


    }
}
