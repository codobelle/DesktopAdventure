using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {
    public int waitingNextLevel;
    int sceneIndex;
    public GameObject particle;
    // Use this for initialization
    void Start () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            StartCoroutine(WaitForNextLevel());
        }
    }
    IEnumerator WaitForNextLevel()
    {
        yield return new WaitForSeconds(waitingNextLevel);
        SceneManager.LoadScene(sceneIndex+1);
    }
}
