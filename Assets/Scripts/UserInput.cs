using DefaultNamespace;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public ModificationManager mm;
    public ObjectModel selectModel;

    private ObjectModel lastModel = null;

    public int layer_mask; 
    // Start is called before the first frame update
    void Start()
    {
        layer_mask =  LayerMask.GetMask("Collider");
        mm = FindObjectOfType<ModificationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,100.0f,layer_mask))
            {
                SelectModel (hit.transform);
                Debug.Log("You selected the " + hit.transform.name);
            }
        }
        
    }

    void SelectModel(Transform model)
    {
        selectModel = model.GetComponent<ObjectModel>();
        selectModel.selected = true;
        mm.actualModel = selectModel;
        if (lastModel==null)
        {
            lastModel = selectModel;
        }
        if (lastModel!=selectModel)
        {
            lastModel.selected = false;
            lastModel = selectModel;
        }
    }


}
