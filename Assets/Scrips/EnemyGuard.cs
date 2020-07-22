using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{

    public LayerMask target;
    public bool targetLocaled = false;
    public float vision = 1.5f;

    AudioSource enemySound;
    public AudioClip shootingSE;

    public Transform bulletSpawner;
    public GameObject bullet;
    public float fireRate = 0.3f;
    float mainTimer;
    public float shootingLapse = 1f;
    float count;
    public int shotCount = 0;
    public int bulletsCant = 3;
    Animator eAnim;
    public bool faceRigth = false;



    void Start()
    {
        eAnim = GetComponent<Animator>();
        enemySound = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        targetLocaled = Physics2D.OverlapCircle(transform.position, vision,target );

        if (targetLocaled)
        {
            Attack();

        }
        else
        {
            eAnim.SetBool("shooting", false);
            shotCount = 0;
            mainTimer = 0;
            count = 0;
        }

    }

    //Microbiologia celular 

    // Update is called once per frame
    void Attack()
    {
        mainTimer += Time.deltaTime;

        if (mainTimer >= shootingLapse)
        {
            count += Time.deltaTime;

            if (count >= fireRate && shotCount < bulletsCant)
            {
                eAnim.SetBool("shooting", true);
                GameObject newBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.identity);
                newBullet.GetComponent<EnemyBulletMan>().faceRigth = faceRigth;

                shotCount++;
                enemySound.PlayOneShot(shootingSE);

                count = 0;
            }
            else if (count >= fireRate && shotCount >= bulletsCant)
            {
                mainTimer = 0;
                shotCount = 0;
                eAnim.SetBool("shooting", false);
            }
        }
    }

    void TouchPlayer()
    {

    }

}
