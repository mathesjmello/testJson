
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
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Root rootClass = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text); 
            Debug.Log(rootClass);
           // Debug.Log(request.downloadHandler.text);
            //Model[] models = JsonHelper.FromJson<Model>(request.downloadHandler.text);
           // modelsInstance = JsonHelper.FromJson<Model>(request.downloadHandler.text);
           // Debug.Log(modelsInstance[0].name);
           // Debug.Log(modelsInstance[1].name);
        }
        
    }
}
