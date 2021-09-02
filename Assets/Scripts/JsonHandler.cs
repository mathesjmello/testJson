using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class JsonHandler : MonoBehaviour
{
    public bool hasSave;
    private string saveJson;
    private string url = "https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json";

    private void CheckLocalSave()
    {
        
        if (File.Exists(Application.persistentDataPath + "/json.txt"))
        {
            saveJson = File.ReadAllText(Application.persistentDataPath + "/json.txt");
            hasSave = true;
        }

        Debug.Log(hasSave);
    }

    public IEnumerator Deserialize(Action<List<Model>> callback)
    {
        CheckLocalSave();
        Model[] model;
        if (!hasSave)
        {
            var mywww = new WWW(url);
            yield return mywww;
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                callback?.Invoke(null);
                yield break;
            }
            else
            {
                string jsonData = System.Text.Encoding.UTF8.GetString(mywww.bytes, 3, mywww.bytes.Length - 3);
                model = JsonHelper.FromJson<Model>(jsonData);
            }
        }
        else
        {
            model = JsonHelper.FromJson<Model>(saveJson);
           
        }
        callback?.Invoke(model.ToList());
    }

    public void SaveFile(string modelsToJson)
    {
        if (hasSave)
        {
            File.Delete(Application.persistentDataPath +"/json.txt");
        }
        File.WriteAllText(Application.persistentDataPath +"/json.txt",modelsToJson);
        Debug.Log("saved on: " + Application.persistentDataPath);
    }
}