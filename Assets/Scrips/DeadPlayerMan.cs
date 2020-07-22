using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerMan : MonoBehaviour
{
    public float speed;
    public float alphaTransition;

    SpriteRenderer spriteRender;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
         spriteRender = GetComponent<SpriteRenderer>();
         rb = GetComponent<Rigidbody2D>();

         rb.velocity = Vector2.up * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float alphaValue = spriteRender.color.a;
        alphaValue -= alphaTransition * Time.deltaTime;

        spriteRender.color = new Color(1, 1, 1, alphaValue);

        if (spriteRender.color.a <= 0)
        {
            Destroy(gameObject);
        }

    }
}
