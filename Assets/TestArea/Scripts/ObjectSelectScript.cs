using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ObjectSelectScript : MonoBehaviour
{
    public TMP_Text MouseOverObjectName;
    public TMP_Text SelectedObjectName;
    public GameObject MouseOver;
    public GameObject SelectedObject;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedObject == null)
        {
            SelectedObjectName.text = "No object selected...";
        }
        else
        {
            SelectedObjectName.text = SelectedObject.name;
        }

        if (MouseOver == null)
        {
            MouseOverObjectName.text = "None...";
        }
        else
        {
            MouseOverObjectName.text = MouseOver.name;
        }

        FindObjectMouseIsOver();

        if (Input.GetMouseButton(0))
        {
            if (MouseOver != null)
            {
                if (MouseOver.GetComponent<NavMeshAgent>() != null) // only want to select navmesh objects at this point.
                {
                    SelectedObject = MouseOver;
                }
            }
            else
            {
                SelectedObject = null;
            }
        }
    }

    protected void FindObjectMouseIsOver()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            MouseOver = hit.collider.gameObject;            
        }
        else
        {
            MouseOver = null;
        }
    }
}
