using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader : MonoBehaviour
{
    public List<string> Names;
    void Start()
    {
        LoadResources();
    }
    void LoadResources()
    {
        foreach (var stg in Names)
        {
            Instantiate(Resources.Load(stg),transform);
        }
    }
}
