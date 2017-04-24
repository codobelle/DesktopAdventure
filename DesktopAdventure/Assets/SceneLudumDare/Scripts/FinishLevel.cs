using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public AudioClip SweetHeartSound;
    private AudioSource source;
    public int TimeWaitingNextLevel;
    int sceneIndex;
    public GameObject particle;
    Animator anim;
    GameObject BackToStart;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        print(SceneManager.sceneCountInBuildSettings);
        anim = GetComponent<Animator>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(SweetHeartSound, 0.7F);
            anim.SetTrigger("HisTouch");
            Instantiate(particle, transform.position, transform.rotation);
            StartCoroutine(WaitForNextLevel());
        }
    }
    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(TimeWaitingNextLevel);
        if (sceneIndex != (SceneManager.sceneCountInBuildSettings-1))
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            GameFinish.finishGame = true;
        }

    }
}
