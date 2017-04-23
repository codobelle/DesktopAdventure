using UnityEngine;
using System.Collections;

public class EnemyMovement: MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    public float speed;
    public bool isMovingRight;

    private Rigidbody2D rb2d;
    private float viewDirection;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (isMovingRight)
        {
            viewDirection = transform.localScale.x;
            changeViewDirection();
        }
        else
        {
            viewDirection = Mathf.Abs(transform.localScale.x);
            changeViewDirection();
        }
    }

    void Update()
    {

        if (isMovingRight && transform.position.x > rightPoint.position.x)
        {
            isMovingRight = false;
            viewDirection = Mathf.Abs(transform.localScale.x);
            changeViewDirection();
        }
        if (!isMovingRight && transform.position.x < leftPoint.position.x)
        {
            isMovingRight = true;
            viewDirection = -transform.localScale.x;
            changeViewDirection();
        }

        if (isMovingRight)
        {
            rb2d.velocity = new Vector3(speed, rb2d.velocity.y, 0f);
        }
        else
        {
            rb2d.velocity = new Vector3(-speed, rb2d.velocity.y, 0f);
        }
    }

    void changeViewDirection()
    {
        transform.localScale = new Vector3(viewDirection, transform.localScale.y, 0f);
    }
}
