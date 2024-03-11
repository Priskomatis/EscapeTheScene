using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    [SerializeField] bool cursorLock = true;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float Speed = 6.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] float gravity = -30f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] private AudioSource footstepsAudio;
    [SerializeField] private AudioClip regularFootstepSound;
    [SerializeField] private AudioClip carpetFootstepSound;

    public float jumpHeight = 6f;
    float velocityY;
    bool isGrounded;

    float cameraCap;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;

    CharacterController controller;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        footstepsAudio = GetComponent<AudioSource>();
        footstepsAudio.clip = regularFootstepSound; // Assign the regular footstep sound
        footstepsAudio.Stop();
    }

    void Update()
    {
        UpdateMouse();
        UpdateMove();

        // Check for player movement and play/stop audio accordingly
        if (currentDir.magnitude > 0.1f && isGrounded)
        {
            if (!footstepsAudio.isPlaying)
            {
                // Start playing footstep audio based on ground material
                if (IsOnCarpet())
                {
                    footstepsAudio.clip = carpetFootstepSound; // Switch to carpet footstep sound
                    Debug.Log("Carpet!");
                }
                else
                {
                    footstepsAudio.clip = regularFootstepSound; // Switch to regular footstep sound
                    Debug.Log("Floor!");
                }

                footstepsAudio.Play();
            }
        }
        else
        {
            // Stop audio when not moving
            footstepsAudio.Stop();
        }
    }

    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (isGrounded)  // Reset velocityY when grounded
        {
            velocityY = -0.001f;  // You can set it to a small negative value to keep the player grounded
        }
        else
        {
            velocityY += gravity * 2f * Time.deltaTime;
        }

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }

    bool IsOnCarpet()
    {
        // Create a Ray from the groundCheck position straight down
        Ray ray = new Ray(groundCheck.position, Vector3.down);

        // Set the maximum distance of the ray based on your needs
        float maxRayDistance = 2f;

        // Perform the raycast
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, LayerMask.GetMask("Carpet")))
        {
            Debug.Log("Hit object layer: " + hit.collider.gameObject.layer);

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Carpet"))
            {
                Debug.Log("Carpet!");
                return true; // The character is on carpet
            }
        }

        return false; // The character is not on carpet
    }
}
