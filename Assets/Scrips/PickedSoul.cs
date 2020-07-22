using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedSoul : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;

    public float lifeTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        rb.velocity = Vector2.up * jumpForce;

        Destroy(gameObject, lifeTime);
    }

}
