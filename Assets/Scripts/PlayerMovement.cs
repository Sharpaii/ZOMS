using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 forceApply;
    public float forceDamp;
    public float dodgeSpeed; // Currently the same speed as moveSpeed, subject to change after testing
    public int dodgeFrames;
    public Vector2 dodgevect;
    public float dodgeScalar;
    public Animator anim;
    public SpriteRenderer sprite;
    public int invincibiliyFrames;


    void Start()
    {
        // Set FPS to 60
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var speedComponent = player.GetComponent<Speed>();
        moveSpeed = speedComponent.currentSpeed;
        Move();
    }

    public void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Flip Character
        if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
        }

        // Animation Logic
        if (moveX == 0 && moveY == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }


        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        Vector2 moveForce = moveDirection * moveSpeed;


        moveForce += forceApply;
        forceApply /= forceDamp;
        if (Mathf.Abs(forceApply.x) <= 0.01f && Mathf.Abs(forceApply.y) <= 0.01f)
        {
            forceApply = Vector2.zero;
        }
        rb.velocity = moveForce;

        // ROLLING FORWARD AND BACKSTEP FUNCTION
        if (Input.GetKeyDown(KeyCode.Space) && moveForce != Vector2.zero && dodgeFrames == 0) // Cannot roll when standing still
        {
            dodgeFrames = 45; // No set FPS yet, TBD
            dodgevect = moveForce.normalized;
            dodgeScalar = 1.0f;
        }
        else if (Input.GetKeyDown(KeyCode.F) && moveForce != Vector2.zero && dodgeFrames == 0) // Buttons for rolling/backstep subject to change
        {
            dodgeFrames = 25;
            Vector2 changeDirection = new Vector2((moveForce.x * -1), (moveForce.y * -1));
            dodgevect = changeDirection.normalized;
            dodgeScalar = 2.0f;
        }

        // TODO: Change this logic for animation purposes
        if (dodgeFrames != 0)
        {
            dodgeFrames -= 1;
            if (dodgeFrames * dodgeScalar > 33)
            {
                rb.velocity = dodgevect.normalized * (dodgeSpeed * 2.0f); // Initial Speed Boost on Roll
            }
            else if (dodgeFrames * dodgeScalar > 20)
            {
                rb.velocity = dodgevect.normalized * dodgeSpeed;
            }
            else
            {
                rb.velocity = dodgevect.normalized * (dodgeSpeed * .4f); // Slower at end of Roll to simulate getting up
                GetComponent<Collider2D>().enabled = true;
            }
        }

        // Invincibility "Animation"
        if (invincibiliyFrames > 0)
        {
            if (invincibiliyFrames > 100)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                invincibiliyFrames--;
            }
            else if (invincibiliyFrames > 75)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                invincibiliyFrames--;
            }
            else if (invincibiliyFrames > 50)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                invincibiliyFrames--;
            }
            else if (invincibiliyFrames > 25)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                invincibiliyFrames--;
            }
            else if (invincibiliyFrames > 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                invincibiliyFrames--;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks for intagibility
        if (dodgeFrames > 0 && collision.collider.CompareTag("Enemy"))
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else if (invincibiliyFrames > 0)
        {

        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            forceApply += new Vector2(20 * (Input.GetAxisRaw("Horizontal") * -1), 20 * (Input.GetAxisRaw("Vertical") * -1));
            anim.SetTrigger("isHit");
            invincibiliyFrames = 125;
        }
    }
}
