using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public AudioClip Jump, Jumped;
    private AudioSource source;
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false, jumped = false;
    public float maxSpeed, speed = 10f, jumpSpeed = 15f;
    public float jumpForce = 1f;
    public Transform groundCheck;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    float h;


    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            source.PlayOneShot(Jump, 0.3F);
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            anim.SetTrigger("Walk");
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if it is left or right?
            if (touchPosition.x < halfScreen)
            {
                //transform.Translate(Vector3.left * speed * Time.deltaTime);
                Vector2 velocity = new Vector2(maxSpeed * Time.deltaTime, rb2d.velocity.y);
                rb2d.MovePosition(rb2d.position - velocity * Time.fixedDeltaTime);
                if (facingRight)
                {
                    Flip();
                }
            }
            else if (touchPosition.x > halfScreen)
            {
                //transform.Translate(Vector3.right * speed * Time.deltaTime);
                Vector2 velocity = new Vector2(maxSpeed * Time.deltaTime, rb2d.velocity.y);
                rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
                if (!facingRight)
                {
                    Flip();
                }
            }
            if (Input.touchCount == 2 && grounded)
            {
                print("Jump");
                //transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
                source.PlayOneShot(Jump, 0.3F);
                jump = true;

            }

        }
        else
        {
            anim.SetTrigger("Idle");
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            anim.SetTrigger("Walk");
        }
        else
            anim.SetTrigger("Idle");

        rb2d.velocity = new Vector2(h * maxSpeed * Time.deltaTime, rb2d.velocity.y);
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        ////////////////////////////////////////////////////////////////////////////////////////////
        if (jump)
        {
            jump = false;
            grounded = false;
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jumped = true;
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

