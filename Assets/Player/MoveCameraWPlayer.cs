using UnityEngine;

public class MoveCameraWPlayer : MonoBehaviour
{
    public Transform cameraPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
