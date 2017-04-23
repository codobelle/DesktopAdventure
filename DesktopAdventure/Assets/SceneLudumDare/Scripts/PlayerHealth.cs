using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip Death;
    private AudioSource source;
    int sceneIndex;
    public int waitingDie = 3;
    CircleCollider2D bc2d;
    Animator anim;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start()
    {
        bc2d = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            source.PlayOneShot(Death, 0.7F);
            anim.SetTrigger("Die");
            bc2d.isTrigger = true;
            StartCoroutine(WaitForDie());
        }

    }
    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(waitingDie);
        SceneManager.LoadScene(sceneIndex);
    }
}
