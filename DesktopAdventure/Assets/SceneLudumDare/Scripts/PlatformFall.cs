using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour
{
    public float fallDelay = 1f;
    
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grounded"))
        {
            Invoke("Fall", fallDelay);
            }
       
    }

    void Fall()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.gravityScale = 10;
        bc2d.isTrigger = true;
    }



}