using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementByButtons : MonoBehaviour {

    public Transform groundCheck;
    private Animator anim;
    Rigidbody2D rb;
    private bool grounded = false;
    public float speed, jumpForce;
    string direction;
    bool facingRight, jump;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (jump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            jump = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {

        if (direction == "Left")
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            //rb.MovePosition(rb.position - velocity * Time.fixedDeltaTime);
            anim.SetTrigger("Walk");
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (direction == "Right")
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            //rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            anim.SetTrigger("Walk");
            if (facingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(0 * Time.deltaTime, rb.velocity.y);
            anim.SetTrigger("Idle");
        }
    }

    public void Move(string mDir)
    {
        direction = mDir;
    }

    public void Jump()
    {
       if (grounded)
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("Jump");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
