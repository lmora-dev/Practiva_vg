using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    Rigidbody2D rb;
    Player_Controller pc;
    RaycastHit2D hit;
    
    [HideInInspector]
    public bool onWall = false;
    //public float jumpSpeed = 2f;
    [HideInInspector]
    public float RayDistance = 0.4f;

    public Player DatosPlayer;
    private float jumpSpeed;

    public Joystick joystick;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<Player_Controller>();
        jumpSpeed = DatosPlayer.WallJumpFuerza;

    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localScale.x, RayDistance);

    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !pc.isGrounded && hit.collider != null && hit.collider.CompareTag("wall"))
        {
            onWall = true;
            rb.velocity = new Vector2(jumpSpeed * hit.normal.x, jumpSpeed);
            

            if (transform.localScale.x == 1)
            {
                transform.localScale = new Vector2(-1, 1);
                pc.FaceDer = false;
            }
            else if (transform.localScale.x == -1)
            {
                transform.localScale = Vector2.one;
                pc.FaceDer = true;
            }
        }

        if (joystick.Vertical > 0.5f && !pc.isGrounded && hit.collider != null && hit.collider.CompareTag("wall"))
        {
            onWall = true;
            rb.velocity = new Vector2(jumpSpeed * hit.normal.x, jumpSpeed);


            if (transform.localScale.x == 1)
            {
                transform.localScale = new Vector2(-1, 1);
                pc.FaceDer = false;
            }
            else if (transform.localScale.x == -1)
            {
                transform.localScale = Vector2.one;
                pc.FaceDer = true;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * RayDistance);
    }

}

