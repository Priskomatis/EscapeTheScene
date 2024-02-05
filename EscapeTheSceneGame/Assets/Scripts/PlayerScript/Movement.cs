using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float rotationX = 0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * speed * Time.deltaTime);

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player's body horizontally based on mouse movement
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically based on mouse movement
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp vertical rotation to avoid over-rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
