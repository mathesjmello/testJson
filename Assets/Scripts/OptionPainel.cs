using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPainel : MonoBehaviour
{
    private GameObject _painel;


    private void Awake()
    {
        _painel = transform.GetChild(0).gameObject;
    }

    public void SetVisible(bool b)
    {
        _painel.SetActive(b);
    }
}
