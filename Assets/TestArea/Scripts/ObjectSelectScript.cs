
using TMPro;
using UnityEngine;
using UnityEngine.AI;

///-------------------------------------------------------------------------------------------------
/// <summary>   An object select script. </summary>
///
/// <remarks>   16/04/2025. </remarks>
///-------------------------------------------------------------------------------------------------

public class ObjectSelectScript : MonoBehaviour
{
    /// <summary>   Name of the mouse over object. </summary>
    public TMP_Text MouseOverObjectName;
    /// <summary>   The selected object name. </summary>
    public TMP_Text SelectedObjectName;
    /// <summary>   The mouse over. </summary>
    public GameObject MouseOver;
    /// <summary>   The selected object. </summary>
    public GameObject SelectedObject;

    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// </summary>
    ///
    /// <remarks>   16/04/2025. </remarks>
    ///-------------------------------------------------------------------------------------------------

    void Start()
    {
        
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Update is called once per frame. </summary>
    ///
    /// <remarks>   16/04/2025. </remarks>
    ///-------------------------------------------------------------------------------------------------

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

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Searches for the first object mouse is over. </summary>
    ///
    /// <remarks>   16/04/2025. </remarks>
    ///-------------------------------------------------------------------------------------------------

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
