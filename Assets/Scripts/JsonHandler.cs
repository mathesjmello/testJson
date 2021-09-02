using System.Collections;
using System.IO;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class JsonHandler : MonoBehaviour
{
    public SceneManager sm;
    public bool hasSave;
    private string saveJson;
    private string url = "https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json";
    void Start()
    {
        sm = FindObjectOfType<SceneManager>();
        if (File.Exists(Application.persistentDataPath +"/json.txt"))
        {
            saveJson = File.ReadAllText(Application.persistentDataPath +"/json.txt");
            hasSave = true;
            
        }
        Debug.Log(hasSave);
        StartCoroutine(Deserialize());
    }

    IEnumerator Deserialize()
    {
        if (!hasSave)
        {
            var mywww = new WWW(url);
            yield return mywww;
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                string jsonData = System.Text.Encoding.UTF8.GetString(mywww.bytes, 3, mywww.bytes.Length - 3);

                Model[] model = JsonHelper.FromJson<Model>(jsonData);
                foreach (var m in model)
                {
                    var pos = new Vector3((float) m.position[0], (float) m.position[1], (float) m.position[2]);
                    var rot = new Vector3((float) m.rotation[0], (float) m.rotation[1], (float) m.rotation[2]);
                    var scl = new Vector3((float) m.scale[0], (float) m.scale[1], (float) m.scale[2]);
                    sm.SetTransform(m.name, pos, rot, scl);
                }
            }
        }
        else
        {
            Model[] model = JsonHelper.FromJson<Model>(saveJson);
            foreach (var m in model)
            {
                var pos = new Vector3((float) m.position[0], (float) m.position[1], (float) m.position[2]);
                var rot = new Vector3((float) m.rotation[0], (float) m.rotation[1], (float) m.rotation[2]);
                var scl = new Vector3((float) m.scale[0], (float) m.scale[1], (float) m.scale[2]);
                sm.SetTransform(m.name,pos,rot,scl);
            }
        }
    }

    public void SaveFile(string modelsToJson)
    {
        if (hasSave)
        {
            File.Delete(Application.persistentDataPath +"/json.txt");
        }
        File.WriteAllText(Application.persistentDataPath +"/json.txt",modelsToJson);
    }
}