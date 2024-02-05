using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 5f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -1*(Input.GetAxis("Horizontal")));

        characterController.Move(move*Time.deltaTime *speed);
    }

}
