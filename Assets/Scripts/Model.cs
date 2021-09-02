using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public  class Model 
    {
        public string name;
        public float[] position;
        public float[] rotation;
        public float[] scale;

        public Model()
        {
            
        }
        public Model(Model model)
        {
            this.name = model.name;
            this.position = new List<float>(model.position).ToArray();
            this.rotation = new List<float>(model.rotation).ToArray();
            this.scale = new List<float>(model.scale).ToArray();
        }
    }
    
}