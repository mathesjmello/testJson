using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SceneManager : MonoBehaviour
    {
        public List<string> prefabStrings;
        public GameObject waitPainel;
        public JsonHandler jH;
        public Button saveBtn;
        public List<ObjectModel> modelsInstance = new List<ObjectModel>();
        public int modelscount;
        public Model[] models;
        public ObjectModel[] modelsList;
        private void Awake()
        {
            saveBtn.onClick.AddListener(SaveToJson);
            LoadResorces();
            jH = FindObjectOfType<JsonHandler>();
        }

        private void LoadResorces()
        {
            foreach (var prefab in prefabStrings)
            {
                GameObject obg =(GameObject) Instantiate(Resources.Load(prefab));
                modelsInstance.Add(obg.GetComponent<ObjectModel>());
            }
        }

        private void SaveToJson()
        {
            var i = 0;
            modelsList = FindObjectsOfType<ObjectModel>();
            
            models = new Model[modelsList.Length];
            for (int n = modelsList.Length - 1; n >= 0; n--)
            {
                var m = new Model();
                var trans = modelsList[n].transform;
                m.name = modelsList[n].name;
                var position = trans.position;
                var eulerAngles = trans.localEulerAngles;
                var localScale = trans.localScale;
                double[] pos = {(double) position.x, (double) position.y, (double) position.z};
                double[] rot = {(double) eulerAngles.x, (double) eulerAngles.y, (double) eulerAngles.z};
                double[] scl = {(double) localScale.x, (double) localScale.y, (double) localScale.z};
                m.position = pos;
                m.rotation = rot;
                m.scale = scl;
                models[i]=m;
                i++;
            }
            string modelsToJson = JsonHelper.ToJson<Model>(models, true);
            jH.SaveFile(modelsToJson);
            
        }
        
        public void SetTransform(string s, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            var model = modelsInstance[modelscount].transform;
            model.position = position;
            model.localEulerAngles = rotation;
            model.localScale = scale;
            modelscount++;
            if (modelscount >= modelsInstance.Count)
            {
                waitPainel.SetActive(false);
            }
        }
    }
}