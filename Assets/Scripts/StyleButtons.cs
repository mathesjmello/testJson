using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleButtons : MonoBehaviour
{
    private OptionPainel _optionPainel;
    public StyleManeger styM;
    private Button _btn;
    public Material mat;
    void Start()
    {
        _optionPainel = FindObjectOfType<OptionPainel>();
        styM = FindObjectOfType<StyleManeger>();
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(SelectMat);
    }

    private void SelectMat()
    {
        if (styM.chosedMat != mat)
        {
            styM.SelectMaterial(mat);
            _optionPainel.SetVisible(true);
        }
        else
        {
            _optionPainel.SetVisible(false);
            styM.SelectMaterial(null);
        }
    }

   
}
