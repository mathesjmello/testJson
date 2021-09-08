using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SceneManager : MonoBehaviour
    {
        public GameObject waitPainel;
        public GameObject Instructions;
        public JsonHandler jH;
        public Button saveBtn;
        private List<ObjectModel> _instances;


        private void Awake()
        {
            waitPainel.SetActive(true);
            saveBtn.onClick.AddListener(SaveToJson);
            
            jH = FindObjectOfType<JsonHandler>();

            StartCoroutine(jH.Deserialize(SetupModels));
        }

        private void SetupModels(List<Model> models)
        {
            _instances = new List<ObjectModel>();
            foreach (var model in models)
            {
                CreateObject(model);
            }
            waitPainel.SetActive(false);
            Instructions.SetActive(true);
        }

        private void CreateObject(Model model)
        {
            var prefab = Resources.Load<ObjectModel>(model.name);
            if (prefab == null)
            {
                Debug.LogError($"cant find {model.name} object");
                return;
            }
            var obj = Instantiate(prefab);
            
            obj.SetUp(model);
            _instances.Add(obj);
            obj.selected = false;
        }

        private void SaveToJson()
        {
            var models = new List<Model>();
            for (int n = _instances.Count - 1; n >= 0; n--)
            {
                var m = _instances[n].GetModel();
                models.Add(m);
            }
            string modelsToJson = JsonHelper.ToJson<Model>(models.ToArray(), true);
            jH.SaveFile(modelsToJson);
            
        }

        public void Duplicate(ObjectModel actualModel)
        {
            CreateObject(new Model(actualModel.GetModel()));
        }
    }
}