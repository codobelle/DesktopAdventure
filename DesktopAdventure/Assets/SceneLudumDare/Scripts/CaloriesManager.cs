using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesManager : MonoBehaviour {

    public Text maxKcal;
    public Text currentKcalText;
    public RectTransform calorieLevelIndicator;
    public static int currentKcal;

    public static bool addedKcal = false;
    // Use this for initialization
    void Start () {

        maxKcal.text = ProfilesManager.maxKcal.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        currentKcalText.text = currentKcal.ToString();
        if (addedKcal)
        {
            calorieLevelIndicator.anchoredPosition = 
                new Vector2(calorieLevelIndicator.anchoredPosition.x + currentKcal, calorieLevelIndicator.anchoredPosition.y);
            addedKcal = false;
        }
        
    }
}
