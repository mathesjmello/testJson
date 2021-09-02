using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectModel : MonoBehaviour
    {
        public bool selected;
        private Model _model;

        public void SetUp(Model model)
        {
            _model = model;
            var pos = new Vector3((float) model.position[0], (float) model.position[1], (float) model.position[2]);
            var rot = new Vector3((float) model.rotation[0], (float) model.rotation[1], (float) model.rotation[2]);
            var scl = new Vector3((float) model.scale[0], (float) model.scale[1], (float) model.scale[2]);
            SetTransform(pos, rot, scl);
        }

        private void SetTransform(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            transform.position = position;
            transform.localEulerAngles = rotation;
            transform.localScale = scale;
            
        }

        public Model GetModel()
        {
            _model.position = new float[]{transform.position.x, transform.position.y, transform.position.z};
            _model.rotation = new float[]{transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z};
            _model.scale = new float[]{transform.localScale.x, transform.localScale.y, transform.localScale.z};
            return _model;
        }
    }
}