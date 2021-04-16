using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niinja : MonoBehaviour
{
    private float jumpS = 10;
    private int vel = 5;
    private int Maxvel = 0;

    private const int Idle = 0;
    private const int Walk = 1;
    private const int Jump = 2;
    private const int Dead = 3;

    private Rigidbody2D rb;
    private Animator animator;

    private bool muerte = false;
    private bool correr = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (correr)
        {
            animator.SetInteger("Estado", Walk);
            rb.velocity = new Vector2(vel, rb.velocity.y);
            //Debug.Log(vel);
            if (Maxvel == 10)
            {
                Debug.Log(vel);
                vel = vel + 5;
                Maxvel = 0;
                Debug.Log(vel);
            }
        }
        else
        {
            animator.SetInteger("Estado", Idle);
            rb.velocity = new Vector2(vel, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpS), ForceMode2D.Impulse);
            animator.SetInteger("Estado", 2);
            correr = false;
        }
        if (muerte)
        {
            animator.SetInteger("Estado", Dead);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Crate")
        {
            correr = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            muerte = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
            Maxvel = Maxvel + 1;
            Debug.Log(Maxvel);
        }
    }

}
