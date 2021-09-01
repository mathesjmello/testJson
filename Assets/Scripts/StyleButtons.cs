using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleButtons : MonoBehaviour
{
    public StyleManeger styM;
    private Button _btn;
    public Material mat;
    void Start()
    {
        styM = FindObjectOfType<StyleManeger>();
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(SelectMat);
    }

    private void SelectMat()
    {
        styM.SelectMaterial(mat);
    }

   
}
