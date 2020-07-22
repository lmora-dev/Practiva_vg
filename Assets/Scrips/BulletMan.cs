using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMan : MonoBehaviour
{

    //public float speed = 7f;
    //public float lifeTime =0.5f;
    //public int damageValue = 1;
    Rigidbody2D rb;
    Player_Controller pc;

    AudioSource myAudio;
    public AudioClip shotSound; 

    public Player DatosPlayer;
    private float speed;
    private float lifeTime;
    public int damageValue;

    void Start()
    {
        speed = DatosPlayer.VelocidadBala;
        lifeTime = DatosPlayer.TiempoExistencia;
        damageValue = DatosPlayer.Danno;
       
        rb = GetComponent<Rigidbody2D>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        myAudio = GetComponent<AudioSource>();

        myAudio.PlayOneShot(shotSound);

        if (pc.FaceDer)
        {
            rb.velocity = new Vector2(speed, rb.velocity.x);
            
        }
        else if (!pc.FaceDer)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.x);
            
        }


        Destroy(gameObject, lifeTime);
        


    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("wall" ))
        {
                Destroy(gameObject);
        }

    }  

}
