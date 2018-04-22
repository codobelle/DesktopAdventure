using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    public InputField weightInput, heightInput;
    public static float minKcal = 1700, maxKcal = 2000;
    //bool isMale;
    //int typeOfActivity;
    //int years;

    // Use this for initialization
    void Start () {
        //float weight = float.Parse(weightInput.text);
        //float height = float.Parse(heightInput.text);
        //minKcal = 10 * weight + 6.25f * height - 5 * years;

        //if (isMale)
        //{
        //    minKcal += 5;
        //}
        //else
        //{
        //    minKcal -= 161;
        //}

        //switch (typeOfActivity)
        //{
        //    case 0:
        //        maxKcal = minKcal * 1.53f; break;
        //    case 1:
        //        maxKcal = minKcal * 1.76f; break;
        //    case 2:
        //        maxKcal = minKcal * 2.25f; break;
        //    default:
        //        break;
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
