using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMan : MonoBehaviour
{
    public int healt = 3;
    public int enemyScore = 200;

    public GameObject enemyBone;
    public bool enemyDead = false;

    BeginManager begin;

    AudioSource enemySound;
    public AudioClip enemyDed;


    void Start()
    {
        begin = GameObject.FindGameObjectWithTag("GameController").GetComponent<BeginManager>();
        enemySound = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            healt -= col.GetComponent<BulletMan>().damageValue;
            Destroy(col.gameObject);

            if (healt <= 0)
            {
                enemySound.PlayOneShot(enemyDed);
                Instantiate(enemyBone, transform.position, Quaternion.identity);
                Destroy(gameObject);
                begin.UpdateScore(enemyScore);


            }
        }
    }
}
