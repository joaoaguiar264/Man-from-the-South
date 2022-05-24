using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // Movimentação
    public float speed;
    public float jumpforce;
    public static bool facingRight = true;
    public bool noChao = false;
    public bool jump;
    private Rigidbody2D rb;
    private Transform groundCheck;
    private Animator anim;


    // Ataque
    private bool ataque;
    public float velocidadebala;
    //public GameObject tiro;
   // public Transform arma;
    public float tps = 0.1f;
    public float tempo;
    public static bool takeDamage = false;


    // Vida
    public static int vidas = 10;
    public bool playerAlive = true;
    public Image damageImage;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    bool damaged;
    public float flashspeed = 0.2f;

    public static float tempoTotal;


    void Start()
    {

        facingRight = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        anim = gameObject.GetComponent<Animator>();
    }

    /*
    void atirar()
    {
        tempo = 0;
        Instantiate(tiro, arma.position, arma.rotation);
    }
    */
    void Update()
    {


        tempoTotal += Time.deltaTime;

        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        /*
        // Ataque
        if (Input.GetKeyDown(KeyCode.C) && tempo > 1 / tps)
        {
            Invoke("reativar", 0.1f);
            anim.SetTrigger("Atacando");
            Invoke("atirar", 0);

        }
        */
        // Damage
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
        }
        damaged = false;

        if (takeDamage == true)
        {
            vidas--;
            damaged = true;
            takeDamage = false;
          //GameMaster.AudioSrcSFX.PlayOneShot(GameMaster.dano);
        }

    }

    void FixedUpdate()
    {
        // Movimentação
        float v = Input.GetAxisRaw("Vertical");

        float h = Input.GetAxisRaw("Horizontal");

        //anim.SetFloat("Velocidade", Mathf.Abs(h));


        rb.velocity = new Vector2(h * speed, rb.velocity.y);


        // Pulo
        if (Input.GetKey(KeyCode.UpArrow) && noChao && playerAlive == true)
        {
            jump = true;
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpforce));
            jump = false;
        }

        // Agachar


        // Flipar
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        // Vidas
        if (vidas <= 0)
        {
            playerAlive = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerStay2D(Collider2D collider)
    {

    }



}

