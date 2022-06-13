using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static float speed;
    public bool alreadyWalking = false;
    public bool alreadyWalking2 = false;
    public int jumpForce;
    Rigidbody2D rb;
    public static bool facingRight = false;
    public bool isGrounded = false;
    private Transform groundCheck;

    public float timer;
    private Animator anim;
    public static int hp = 10;

    public static bool takeDamage;

    public GameObject fireFinger;
    public Transform firePoint;
    public float time;
    public float cadence = 0.5f;

    public static bool fireComing;
    public int max = 5;

    public GameObject jumpSpace0;
    public GameObject jumpSpace1;
    public GameObject jumpSpace2;

    public bool enemyAlive = true;
    public static bool alreadyDead = false;

    public GameObject halfWinLine;
    public GameObject halfWinLine2;
    public GameObject halfWinLine3;
    public bool halfwin;
    public GameObject dyingLine;

    public GameObject Win;

    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        halfwin = false;
        hp = 10;
        alreadyDead = false;
        facingRight = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        cadence = 1.5f;

    }

    void Update()
    {
        if (Player.hp == 5 && halfwin == false)
        {
            halfwin = true;
            StartCoroutine(HalfWin());
        }

        if(takeDamage == true && alreadyDead == false && speed == 0)
        {
            hp = hp - 1;
            anim.SetTrigger("Damaged");
            takeDamage = false;
        }

        if(hp > 6)
        {
            max = 5;
        }
        else if(hp > 3 && hp <= 6)
        {
            jumpSpace0.SetActive(false);
            jumpSpace1.SetActive(true);
            max = 10;
            if(alreadyWalking == false)
            {
                speed = -0.5f;
                anim.SetFloat("Speed", 1);
                alreadyWalking = true;
            }
            
        }
        else if(hp <= 3)
        {
            cadence = 0.9f;
            jumpSpace1.SetActive(false);
            jumpSpace2.SetActive(true);
            if (alreadyWalking2 == false)
            {
                speed = -0.5f;
                anim.SetFloat("Speed", 1);
                alreadyWalking2 = true;
            }
        }

        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


        if (fireComing == true && alreadyDead == false)
        {
            fireComing = false;
            Dodge();
        }

        if (hp <= 0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

            enemyAlive = false;
            Win.gameObject.SetActive(true);

        }

        timer += Time.deltaTime;

        if (timer >= cadence && isGrounded == true && Player.alreadyDead == false && alreadyDead == false)
        {
            Instantiate(fireFinger, firePoint.position, firePoint.rotation);
            anim.SetTrigger("Attack");
            timer = 0;
        }

        if (enemyAlive == false && alreadyDead == false)
        {
            StartCoroutine(Dying());

            anim.SetTrigger("isDead");
            alreadyDead = true;
        }
        else
        {
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            
        }

        if ((collision.gameObject.tag == "Stop1"))
        {
            speed = 0;
            anim.SetFloat("Speed", 0);
        }

        if ((collision.gameObject.tag == "Stop2"))
        {
            speed = 0;
            anim.SetFloat("Speed", 0);
        }

        if (collision.gameObject.tag == "Borda")
        {
            Flip();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;
    }

    IEnumerator HalfWin()
    {
        if(jumpSpace0.activeInHierarchy == true)
        {
            halfWinLine3.SetActive(true);
            yield return new WaitForSeconds(2);
            halfWinLine3.SetActive(false);
        }
        if (jumpSpace1.activeInHierarchy == true)
        {
            halfWinLine2.SetActive(true);
            yield return new WaitForSeconds(2);
            halfWinLine2.SetActive(false);
        }
        if (jumpSpace2.activeInHierarchy == true)
        {
            halfWinLine.SetActive(true);
            yield return new WaitForSeconds(2);
            halfWinLine.SetActive(false);
        }


    }

    IEnumerator Dying()
    {
        dyingLine.SetActive(true);
        yield return new WaitForSeconds(2);
        dyingLine.SetActive(false);
    }
    void Dodge()
    {
        int random = Random.Range(1, max + 1);

        if(hp <= 3)
        {
            if (random == 1 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9 || random == 10)
            {

                if (isGrounded)
                {
                    rb.AddForce(new Vector2(0, jumpForce));
                }

            }

            else if (random == 2)
            {
            }
        }
        else
        {
            if (random == 1 || random == 3 || random == 5 || random == 7 || random == 9 || random == 8 || random == 10)
            {

                if (isGrounded)
                {
                    rb.AddForce(new Vector2(0, jumpForce));
                }

            }

            else if (random == 2 || random == 4 || random == 6)
            {
            }
        }

        
    }
    void OnDestroy()
    {


    }



}



