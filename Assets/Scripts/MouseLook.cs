using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class MouseLook : MonoBehaviour
{
    // variables determine in-game mouse sensitivity and how hard view is restricted (could be user input!)
    public float mouseSensitivity = 600.0f;
    public float clampAngle = 80.0f;
    public Transform playerBody;

    //xRotation rotates around x-axis (up and down) and y rotation around y-axis (left and right), standard is 0
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        // locks cursor to center of game window and hides it
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 rotate = transform.localRotation.eulerAngles;
        yRotation = rotate.y;
        xRotation = rotate.x;
    }

    void Update()
    {
        // get mouse axis input and apply mouse sensitivity and multiply by Time.deltaTime for frame independence
        // camera moves in direction the mouse moves (change -/+ to invert this)
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        xRotation += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // clamp mouse rotation 
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);

        // perform rotation via the transform (Quaternion used to represent rotation)
        Quaternion localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        transform.rotation = localRotation;

        // rotate the player body (on the y-axis) according to where they look
        playerBody.Rotate(Vector3.up * Input.GetAxis("Mouse X"));
    }
}
