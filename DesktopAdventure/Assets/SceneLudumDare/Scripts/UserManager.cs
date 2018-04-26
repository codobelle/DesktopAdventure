using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserManager : MonoBehaviour {
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";
    public string url = "https://drive.google.com/uc?export=download&id=1dRnPu0jgBq8hA4Lbu8rumuTq4tClHYtZ";
    string jsonString;
    User userData;
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error == null)
            {
                string json = www.text;
                print("fromServer");
                userData = JsonUtility.FromJson<User>(json);
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
                string filePath = Application.dataPath + gameDataProjectFilePath;

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    userData = JsonUtility.FromJson<User>(json);
                }
                else
                {
                    Debug.LogError("Cannot load game data!");
                }
            }
        }
    }

    public void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(userData);

        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);

    }
}
