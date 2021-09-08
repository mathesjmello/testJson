using DefaultNamespace;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public ModificationManager mm;
    public ObjectModel selectModel;
    public GameObject modPainel;
    private ObjectModel _lastModel = null;
    public GameObject Instruction;
    
    public int layer_mask; 
    // Start is called before the first frame update
    void Start()
    {
        layer_mask =  LayerMask.GetMask("Collider");
        mm = FindObjectOfType<ModificationManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,100.0f,layer_mask))
            {
                SelectModel (hit.transform);
            }
        }
        
    }

    void SelectModel(Transform model)
    {
        if (Instruction.activeSelf)
        {
            Instruction.SetActive(false);
        }
        modPainel.SetActive(true);
        selectModel = model.GetComponent<ObjectModel>();
        selectModel.selected = true;
        mm.actualModel = selectModel;
        if (_lastModel==null)
        {
            _lastModel = selectModel;
        }
        if (_lastModel!=selectModel)
        {
            _lastModel.selected = false;
            _lastModel = selectModel;
        }
    }


}
