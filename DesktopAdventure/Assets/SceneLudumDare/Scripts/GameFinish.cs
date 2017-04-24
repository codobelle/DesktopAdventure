using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour {

   public GameObject buttonDialogWindow;
    public static bool finishGame = false;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (finishGame)
        {
            Time.timeScale = 0.0f;
            buttonDialogWindow.SetActive(true);
            finishGame = false;
        }
	}
    
    public void BackToStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
