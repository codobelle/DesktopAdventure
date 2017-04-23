using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    int sceneIndex;
    public GameObject help, team;
    // Use this for initialization
    void Start () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartButton()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    public void HelpButton()
    {
        help.SetActive(true);
    }
    public void TeamButton()
    {
        team.SetActive(true);
    }

    public void ExitPanel()
    {
        help.SetActive(false);
        team.SetActive(false);
    }
    public void CheckGame()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Casapciuc.Celest");
    }
}
