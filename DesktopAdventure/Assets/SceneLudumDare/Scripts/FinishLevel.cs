using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {
    public int TimeWaitingNextLevel;
    int sceneIndex;
    public GameObject particle;
    Animator anim;
        // Use this for initialization
        void Start ()
    {
        anim = GetComponent<Animator>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("HisTouch");
            Instantiate(particle, transform.position, transform.rotation);
            StartCoroutine(WaitForNextLevel());
        }
    }
    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(TimeWaitingNextLevel);
        SceneManager.LoadScene(sceneIndex+1);
    }
}
