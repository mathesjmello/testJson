using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ModificationManager: MonoBehaviour
    {
        public int rotationForce = 15;
        public Button Pos, Rot, Sca, Sty, Dup;
        public Mod ModState;
        public ObjectModel actualModel;
        private SceneManager _sm;

        public enum Mod
        {
            None,
            Position,
            Rotation,
            Scale,
        }
            
        private void Start()
        {
            _sm = FindObjectOfType<SceneManager>();
            Pos.onClick.AddListener(PosControl);
            Rot.onClick.AddListener(RotControl);
            Sca.onClick.AddListener(ScaControl);
            Dup.onClick.AddListener(DupControl);
        }

        private void DupControl()
        {
            _sm.Duplicate(actualModel);
        }
        

        private void ScaControl()
        {
            ModState = Mod.Scale;
        }

        private void RotControl()
        {
            ModState = Mod.Rotation;
        }

        private void PosControl()
        {
            ModState = Mod.Position;
        }
        public void AddX()
        {
            switch (ModState)
            {
                case Mod.Position:
                    actualModel.transform.position+= Vector3.right;
                    break;
                case Mod.Rotation:
                    actualModel.transform.eulerAngles += Vector3.right*rotationForce;
                    break;
                case Mod.Scale:
                    actualModel.transform.localScale += Vector3.right;
                    break;
            }
        }
        public void AddY()
        {
            switch (ModState)
            {
                case Mod.Position:
                    actualModel.transform.position+= Vector3.up;
                    break;
                case Mod.Rotation:
                    actualModel.transform.eulerAngles += Vector3.up*rotationForce;
                    break;
                case Mod.Scale:
                    actualModel.transform.localScale += Vector3.up;
                    break;
            }
        }
        public void AddZ()
        {
            switch (ModState)
            {
                case Mod.Position:
                    actualModel.transform.position+= Vector3.forward;
                    break;
                case Mod.Rotation:
                    actualModel.transform.eulerAngles += Vector3.forward*rotationForce;
                    break;
                case Mod.Scale:
                    actualModel.transform.localScale += Vector3.forward;
                    break;
            }
        }
        public void SubX()
        {
            switch (ModState)
            {
                case Mod.Position:
                    actualModel.transform.position+= Vector3.left;
                    break;
                case Mod.Rotation:
                    actualModel.transform.eulerAngles += Vector3.left*rotationForce;
                    break;
                case Mod.Scale:
                    actualModel.transform.localScale += Vector3.left;
                    break;
            }
        }
        public void SubY()
        {
            switch (ModState)
            {
                case Mod.Position:
                    actualModel.transform.position+= Vector3.down;
                    break;
                case Mod.Rotation:
                    actualModel.transform.eulerAngles += Vector3.down*rotationForce;
                    break;
                case Mod.Scale:
                    actualModel.transform.localScale += Vector3.down;
                    break;
            }
        }
        public void SubZ()
        {
            switch (ModState)
            {
                case Mod.Position:
                    actualModel.transform.position+= Vector3.back;
                    break;
                case Mod.Rotation:
                    actualModel.transform.eulerAngles += Vector3.back*rotationForce;
                    break;
                case Mod.Scale:
                    actualModel.transform.localScale += Vector3.back;
                    break;
            }
        }

    }
}