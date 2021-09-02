
using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class JsonHandler : MonoBehaviour
{
    public int modelscount;
    public List<Model> modelsInfo = new List<Model>();
    public List<ObjectModel> modelsInstance;
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
            var jo = JObject.Parse(jsonData);

            for (int i = 0; i<5; i++)
            {
                JArray jArrayPos = (JArray) jo["models"][i]["position"];
                JArray jArrayRot = (JArray) jo["models"][i]["rotation"];
                JArray jArrayScl = (JArray) jo["models"][i]["scale"];
                var listPos = jArrayPos.ToObject<List<int>>();
                var listRot = jArrayRot.ToObject<List<int>>();
                var listScl = jArrayScl.ToObject<List<int>>();
                var pos = new Vector3(listPos[0], listPos[1], listPos[2]);
                var rot = new Vector3(listRot[0], listRot[1], listRot[2]);
                var scl = new Vector3(listScl[0], listScl[1], listScl[2]);
                modelsInfo.Add(new Model());
                modelsInfo[i].name = jo["models"][i]["name"].Value<string>();
                modelsInfo[i].position = pos;
                modelsInfo[i].rotation = rot;
                modelsInfo[i].scale = scl;
                CreateModel(modelsInfo[i].name,modelsInfo[i].position,modelsInfo[i].rotation,modelsInfo[i].scale);
            }
        }
        
    }

    private void CreateModel(string s, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        var obj = Instantiate(modelsInstance[modelscount].gameObject);
        modelsInstance[modelscount].name = s;
        modelsInstance[modelscount].position = position;
        modelsInstance[modelscount].rotation = rotation;
        modelsInstance[modelscount].scale = scale;
        
        modelscount++;
    }

}