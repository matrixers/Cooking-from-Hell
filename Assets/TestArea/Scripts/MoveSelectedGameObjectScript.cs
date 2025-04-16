
using UnityEngine;
using UnityEngine.AI;

///-------------------------------------------------------------------------------------------------
/// <summary>   A move selected game object script. </summary>
///
/// <remarks>   16/04/2025. </remarks>
///-------------------------------------------------------------------------------------------------

public class MoveSelectedGameObjectScript : MonoBehaviour
{
    /// <summary>   The object select script. </summary>
    protected ObjectSelectScript _objSelectScript;

    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Start is called once before the first execution of Update after the MonoBehaviour is created.
    /// </summary>
    ///
    /// <remarks>   16/04/2025. </remarks>
    ///-------------------------------------------------------------------------------------------------

    void Start()
    {
        _objSelectScript = FindAnyObjectByType<ObjectSelectScript>();
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Update is called once per frame. </summary>
    ///
    /// <remarks>   16/04/2025. </remarks>
    ///-------------------------------------------------------------------------------------------------

    void Update()
    {
        if (_objSelectScript != null)
        {
            // do we have a selected object and a mouse down event, and we are not clicking on another nav agent?
            if (_objSelectScript.SelectedObject != null && Input.GetMouseButton(0) && _objSelectScript.MouseOver.GetComponent<NavMeshAgent>() == null)
            {
                // move the blighter to the selected spot!
                Vector3 pos = GetSelectedPosition(_objSelectScript.SelectedObject);

                NavMeshAgent agent = _objSelectScript.SelectedObject.GetComponent<NavMeshAgent>();

                if (agent != null)
                {
                    agent.updateRotation = true;
                    agent.angularSpeed = 360f; // Make sure it's not 0!

                    agent.SetDestination(pos);
                }
            }
        }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Gets selected position. </summary>
    ///
    /// <remarks>   16/04/2025. </remarks>
    ///
    /// <param name="gameObject">   The game object. </param>
    ///
    /// <returns>   The selected position. </returns>
    ///-------------------------------------------------------------------------------------------------

    protected Vector3 GetSelectedPosition(GameObject gameObject)
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return gameObject.transform.position;
    }
}
