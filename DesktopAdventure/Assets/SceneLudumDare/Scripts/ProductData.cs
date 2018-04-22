using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProductData : MonoBehaviour
{
    private string gameDataProjectFilePath = "/data.json";
    public string url = "https://drive.google.com/uc?export=download&id=1MUeca24V1MB3vYSdXrOcUHr--rW_rFhr";
    string jsonString;
    public Product product;
    IEnumerator Start()
    {
        WWW www = new WWW(url);
        using (www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
            {
                LoadGameData();
            }
            else
            {
                jsonString = www.text;
                print(jsonString);
                product = JsonUtility.FromJson<Product>(jsonString);
                print(product);
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void LoadGameData()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            product = JsonUtility.FromJson<Product>(dataAsJson);
        }
        else
        {
            product = new Product();
        }
    }

    private void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(product);

        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);

    }
}

