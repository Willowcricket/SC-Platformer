using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator anime;

    public float speed = 5.0f;
    public float jumpForce = 450.0f;
    public bool isGrounded = false;
    public Transform groundChTF;
    public int jumps = 1;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anime = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movment
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        if (rb2d.velocity.x < 0)
        {
            sr.flipX = true;
            PlayAnime();
        }
        else if (rb2d.velocity.x > 0)
        {
            sr.flipX = false;
            PlayAnime();
        }
        else
        {
            PlayAnime();
        }

        //Detect if player is on something
        RaycastHit2D hitInfo = Physics2D.Raycast(groundChTF.position, Vector2.down, 0.1f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Starting jump settings memory
        if (isGrounded == true)
        {
            jumps = 1;
            jumpForce = 450.0f;
        }

        InputHandler();
    }

    //How to select anime
    private void PlayAnime()
    {
        if (isGrounded != true)
        {
            anime.Play("PlayerJump");
        }
        else if (rb2d.velocity.x == 0)
        {
            anime.Play("PlayerIdle");
        }
        else if (rb2d.velocity.x != 0)
        {
            anime.Play("PlayerWalk");
        }
    }

    private void InputHandler()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumps != 0)
            {
                if (isGrounded != true)
                {
                    jumps--;
                    jumpForce = 250.0f;
                }
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
    }
}
