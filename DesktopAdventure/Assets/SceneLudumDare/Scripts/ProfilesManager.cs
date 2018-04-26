using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfilesManager : MonoBehaviour {

    public GameObject profilePanel0, profilePanel1, profilePanel2, profilePanel3;
    public InputField userNameInput, heightInput, weightInput;
    public Text result;
    User userData;
    User.UserData user;
    UserManager userManager;
    public static float minKcal = 1700, maxKcal = 2000;
    bool isMale = true;
    int years, typeOfActivity, height, weight;
    // Use this for initialization
    void Start () {
        userManager = new UserManager();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenProfileGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void NewUser()
    {
        profilePanel0.SetActive(false);
        profilePanel1.SetActive(true);
        
    }

    public void NextPanel()
    {

        userData = new User();
        user = new User.UserData();
        user.name = userNameInput.text.ToString();
        profilePanel1.SetActive(false);
        profilePanel2.SetActive(true);
    }

    public void NextPanelResult()
    {
        height = int.Parse(heightInput.text);
        user.height = height;
        weight = int.Parse(weightInput.text);
        user.weight = weight;
        profilePanel2.SetActive(false);
        profilePanel3.SetActive(true);

        minKcal = 10 * weight + 6.25f * height - 5 * years;

        if (isMale)
        {
            minKcal += 5;
        }
        else
        {
            minKcal -= 161;
        }

        switch (typeOfActivity)
        {
            case 0:
                maxKcal = minKcal * 1.53f; break;
            case 1:
                maxKcal = minKcal * 1.76f; break;
            case 2:
                maxKcal = minKcal * 2.25f; break;
            default:
                break;
        }
        result.text = maxKcal.ToString();
        userData.users.Add(user);
        userManager.SaveGameData();
    }

    public void SetTypeOfActivity(int type)
    {
        typeOfActivity = type;
    }

    public void SetUserYears(int category)
    {
        switch (category)
        {
            case 0:
                years = (13 + 17) / 2; break;
            case 1:
                years = (18 + 21) / 2; break;
            case 2:
                years = (22 + 30) / 2; break;
            case 3:
                years = (30 + 50) / 2; break;
            default:
                break;
        }
    }
}
