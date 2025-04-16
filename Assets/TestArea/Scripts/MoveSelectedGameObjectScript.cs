using UnityEngine;
using UnityEngine.AI;

public class MoveSelectedGameObjectScript : MonoBehaviour
{
    protected ObjectSelectScript _objSelectScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _objSelectScript = FindAnyObjectByType<ObjectSelectScript>();
    }

    // Update is called once per frame
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
