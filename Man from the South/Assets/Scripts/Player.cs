using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpforce;
    public static bool facingRight = true;
    public bool isGrounded = false;
    public bool jump;
    private Rigidbody2D rb;
    private Transform groundCheck;
    private Animator anim;
    public static bool stopPlayer = false;

    public GameObject projectile;
    public Transform firePoint;
    public float time;
    public float tps = 0.1f;


    public static bool takeDamage = false;
    public static int hp = 10;
    public static bool alreadyDead = false;
    public bool playerAlive = true;
    public Image damageImage;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public float flashspeed = 0.2f;


    void Start()
    {
        hp = 10;
        alreadyDead = false;
        stopPlayer = false;
        facingRight = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        anim = gameObject.GetComponent<Animator>();
    }

    
    void Attack()
    {
        time = 0;
        Instantiate(projectile, firePoint.position, projectile.transform.rotation);
    }
    
    void Update()
    {
        time += Time.deltaTime;

        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        

        // Attack
        if (Input.GetKeyDown(KeyCode.C) && time > 1 / tps && GameMaster.bossFightBool == true && alreadyDead == false && isGrounded == true)
        {
            anim.SetTrigger("Attack");
            Invoke("Attack", 0);

        }

        if (hp <= 0)
        {
            playerAlive = false;
        }

        if (takeDamage == true && alreadyDead == false)
        {
            hp = hp -1;
            anim.SetTrigger("Damaged");
            damageImage.color = flashColor;
            takeDamage = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
        }


        if (playerAlive == false && alreadyDead == false)
        {
            anim.SetTrigger("isDead");
            alreadyDead = true;
        }
        else
        {
        }
    }

    void FixedUpdate()
    {

        if(stopPlayer == false && playerAlive == true)
        {
            float v = Input.GetAxisRaw("Vertical");

            float h = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(h * speed, rb.velocity.y);

             anim.SetFloat("Speed", Mathf.Abs(h));

            if (h > 0 && !facingRight)
            {
                Flip();
            }
            else if (h < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        
        
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded && playerAlive == true && stopPlayer == false && GameMaster.bossFightBool == true)
        {
            jump = true;
        }

        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpforce));
            jump = false;
        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Dialog"))
        {
            stopPlayer = true;
            GameMaster.dialogOn = true;
        }

        if (collider.gameObject.CompareTag("Key"))
        {
            Destroy(collider.gameObject);
            GameMaster.screenText = true;
            GameMaster.win2 = true;
        }

        if (collider.gameObject.CompareTag("Car"))
        {

        }
    }



}

