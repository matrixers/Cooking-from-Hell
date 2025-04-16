
using UnityEngine;

///-------------------------------------------------------------------------------------------------
/// <summary>   A test camera controller script. </summary>
///
/// <remarks>   16/04/2025. </remarks>
///-------------------------------------------------------------------------------------------------

public class TestCameraControllerScript : MonoBehaviour
{
    /// <summary>   The translate speed. </summary>
    public float TranslateSpeed = 10;
    /// <summary>   The rotation speed. </summary>
    public float RotationSpeed = 50;
    /// <summary>   True to rotate with mouse. </summary>
    public bool RotateWithMouse = true;

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
