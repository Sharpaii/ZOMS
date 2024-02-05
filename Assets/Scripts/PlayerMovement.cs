using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 forceApply;
    public float forceDamp;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY =  Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        Vector2 moveForce = moveDirection * moveSpeed;

        moveForce += forceApply;
        forceApply /= forceDamp;
        if (Mathf.Abs(forceApply.x) <= 0.01f && Mathf.Abs(forceApply.y) <= 0.01f)
        {
            forceApply = Vector2.zero;
        }
        rb.velocity = moveForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            forceApply += new Vector2(-20, 0);
        }
    }
}
