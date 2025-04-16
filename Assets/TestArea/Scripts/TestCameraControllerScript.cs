using UnityEngine;

public class TestCameraControllerScript : MonoBehaviour
{
    public float TranslateSpeed = 10;
    public float RotationSpeed = 50;
    public bool RotateWithMouse = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 fwd = transform.forward;
            fwd.y = 0;
            fwd.Normalize();
            transform.Translate(fwd * TranslateSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 bck = -transform.forward;
            bck.y = 0;
            bck.Normalize();
            transform.Translate(bck * TranslateSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * TranslateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * TranslateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, RotationSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
