using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    WallJump wj;

    //Ref a animator
    Animator myAnim;

    //Velocidad del personaje
    //public float moveSpeed = 40f;
    //Player mira a la derecha por default
    [HideInInspector]
    public bool FaceDer = true;

    

    //Variables para saltar
    public Transform groundCheck;
    //Cuan grande interacción con el suelo
    [HideInInspector]
    public float checkRadius = 0.05f;
    //cual es el leyer para sber cual es el suelo
    public LayerMask whatIsGround;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool canMove = true;
    
    public Joystick joystick;

    //Esto es magico y es el ObjectScriptable o: Es nuevo, lo acabo conocer jeje
    public Player DatosPlayer;
    private float moveSpeed;
    private float JumpForce;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        wj = GetComponent<WallJump>();
        moveSpeed = DatosPlayer.VelocidadJugador;
        JumpForce = DatosPlayer.FuerzaSalto;

    }

    //Llama constantemnente, constante segun la fisica del engine
    private void FixedUpdate()
    {
        //Se está en el suelo, si en el circulo, segun la posicon del ground check, el radio, y lo que se considera en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        myAnim.SetBool("grounded", isGrounded);

        if (isGrounded) 
        {
            wj.onWall = false;
        }        
    }


    void Update()
    {
        if (!wj.onWall && canMove)
        {
            PlayerMovement();
            PlayerJump();
            
        } 
    }

   
    
    void PlayerMovement()
    {

        //calcula valor en el input horizontal * velocidad de movimiento creando un valor de movimiento global 

        float move = (Input.GetAxisRaw("Horizontal") + joystick.Horizontal) * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(move, rb.velocity.y);

        //Si el valor es negativo y mi carita no está a la derecha, flipeo y lo mismo
        if (move >0 && !FaceDer || move <0 && FaceDer)
        {
            FlipPlayer();

        }

        myAnim.SetFloat("Speed", Mathf.Abs(move));
    }

    public void FlipPlayer()
    {
        //Si miramos a la derecha, cambimos a la izquierda y viseversa 
        FaceDer = !FaceDer;

        //Le da valor a obj actual
        Vector3 curScale = transform.localScale;

        //El valor *-1 para tener el opuesto. 1 to -1
        curScale.x *= -1;

        //Ahora si hace flipcito uwu
        transform.localScale = curScale;

    }

    void PlayerJump()
    {

        //Cuando se pulse el boton que se llama salto y esté en el suelo hará la acción
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        
        if (joystick.Vertical > 0.5f && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        myAnim.SetFloat("vertSpeed", rb.velocity.y);



    }
}
