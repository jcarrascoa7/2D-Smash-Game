using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Float parameters
    public float health;
    public float maxHealth;
    public float stamina;
    private float staminaRegen;
    public float maxStamina;
    private float speed = 5f;
    private float jumpForce = 7f;
    public float power;
    public float ultimateCharge;

    private float movementX;
    private float movementY;

    // Bool parameters
    public bool isDead;
    public bool ultimateAvailable;

    // Components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    
    // Animations
    private string RUN_ANIMATION = "run";
    private string GROUNDED_ANIMATION = "isGrounded";

    // Methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movePlayer();
        animatePlayer();
    }

    private void movePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;

        pos.x += movementX * speed * Time.deltaTime;

        if (movementY > 0)
        {
            pos.y += movementY * jumpForce * Time.deltaTime;
        }

        transform.position = pos;
    }

    private void animatePlayer()
    {
        Vector2 pos = transform.position;

        if (movementX > 0)
        {
            if (movementY == 0)
            {
                biggerSprite();
                anim.SetBool(GROUNDED_ANIMATION, true);
                anim.SetBool(RUN_ANIMATION, true);
                sr.flipX = false;
            }
            else if (movementY > 0)
            {
                smallerSprite();
                anim.SetBool(GROUNDED_ANIMATION, false);
                anim.SetBool(RUN_ANIMATION, false);
                sr.flipX = false;
            }
        }
        else if (movementX < 0)
        {
            if (movementY == 0)
            {
                biggerSprite();
                anim.SetBool(GROUNDED_ANIMATION, true);
                anim.SetBool(RUN_ANIMATION, true);
                sr.flipX = true;
            }
            else if (movementY > 0)
            {
                smallerSprite();
                anim.SetBool(GROUNDED_ANIMATION, false);
                anim.SetBool(RUN_ANIMATION, false);
                sr.flipX = true;
            }
        }
        else
        {
            if (movementY == 0)
            {
                biggerSprite();
                anim.SetBool(GROUNDED_ANIMATION, true);
                anim.SetBool(RUN_ANIMATION, false);
            }
            else if (movementY > 0)
            {
                smallerSprite();
                anim.SetBool(GROUNDED_ANIMATION, false);
                anim.SetBool(RUN_ANIMATION, false);
            }
        }
    }

    private void biggerSprite()
    {
        Vector2 scale = transform.localScale;
        scale.x = 2.3f;
        scale.y = 2.3f;
        transform.localScale = scale;
    }

    private void smallerSprite()
    {
        Vector2 scale = transform.localScale;
        scale.x = 1.2f;
        scale.y = 1.2f;
        transform.localScale = scale;
    }

}
