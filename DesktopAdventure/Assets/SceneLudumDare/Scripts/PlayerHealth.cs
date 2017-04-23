using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    int sceneIndex;
    public int waitingDie = 3;
    BoxCollider2D bc2d;
    // Use this for initialization
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
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
