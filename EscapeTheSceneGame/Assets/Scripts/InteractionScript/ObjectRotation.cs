using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f; // Adjust the speed as needed

    void Update()
    {
        // Rotate the object around its up axis (Y-axis) continuously
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
