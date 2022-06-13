using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFinger : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 direction;
    protected float anim;

    public bool hasShot = false;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Enemy.facingRight == true)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        StartCoroutine(Foward());
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Player.takeDamage = true;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Border"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Foward()
    {
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject, 3f);

        if (facingRight == true)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }


    }
}
