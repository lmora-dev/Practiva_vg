using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMan : MonoBehaviour
{
    public float bulletSpeed = 3f;
    Rigidbody2D rb;

    public int damageValue = 1;

    public bool faceRigth;

    public float lifeTIme = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = faceRigth ? Vector2.right * bulletSpeed : Vector2.left * bulletSpeed;

        Destroy(gameObject, lifeTIme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
