using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Model : MonoBehaviour
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public bool selected;
    }
    
}