using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class StyleManeger : MonoBehaviour
{
    public Model SelectedModel;
    public Material chosedMat;
    public Texture strips, circles, triangles;
    public Button btnL, btnC, btnT, btnR, btnG, btnW;

    private void Start()
    {
        btnL.onClick.AddListener(StripsAplay);
        btnC.onClick.AddListener(CirclesAplay);
        btnT.onClick.AddListener(TrianglesAplay);
        btnR.onClick.AddListener(RedAplay);
        btnG.onClick.AddListener(GreenAplay);
        btnW.onClick.AddListener(WhiteAplay);
    }

    public void SelectMaterial(Material mat)
    {
        chosedMat = mat;
    }
    private void WhiteAplay()
    {
        chosedMat.color = Color.white;
    }

    private void GreenAplay()
    {
        chosedMat.color = Color.green;
    }

    private void RedAplay()
    {
        chosedMat.color = Color.red;
    }

    private void TrianglesAplay()
    {
        chosedMat.SetTexture("_MainTex",triangles);
    }

    private void CirclesAplay()
    {
        chosedMat.SetTexture("_MainTex",circles);
    }

    private void StripsAplay()
    {
        chosedMat.SetTexture("_MainTex",strips);
    }
}
