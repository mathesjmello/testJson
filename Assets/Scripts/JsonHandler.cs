
using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class JsonHandler : MonoBehaviour
{
    Model[] modelsInstance = new Model[5];
    private string url = "https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json";
    void Start()
    {
        
        StartCoroutine(Deserialize());
    }

    IEnumerator Deserialize()
    {
        WWW mywww = new WWW(url);
        yield return mywww;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        { 
            string jsonData = System.Text.Encoding.UTF8.GetString(mywww.bytes,3,mywww.bytes.Length -3);
            Model[] models = JsonHelper.FromJson<Model>(jsonData);
           //modelsInstance = JsonHelper.FromJson<Model>(request.downloadHandler.text);
           Debug.Log(models[0]);
           //Debug.Log(models[0]);
        }
        
    }
}
