using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProductData : MonoBehaviour
{
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";
    public string url = "https://drive.google.com/uc?export=download&id=1dRnPu0jgBq8hA4Lbu8rumuTq4tClHYtZ";
    string jsonString;
    Product product;
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error == null)
            {
                string json = www.text;
                print("fromServer");
                product = JsonUtility.FromJson<Product>(json);
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
                string filePath = Application.dataPath + gameDataProjectFilePath;

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    product = JsonUtility.FromJson<Product>(json);
                }
                else
                {
                    Debug.LogError("Cannot load game data!");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

