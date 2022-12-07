using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSens;
    [SerializeField] private Transform target;
    private bool mouseDown;

    void Update()
    {
        if (Input.GetMouseButton(2))
            mouseDown = true;
        if (Input.GetMouseButtonUp(2))
            mouseDown = false;

        if(mouseDown)
        {
            float angle = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            transform.RotateAround(target.position, Vector3.up, angle);
        }     
    }
}
