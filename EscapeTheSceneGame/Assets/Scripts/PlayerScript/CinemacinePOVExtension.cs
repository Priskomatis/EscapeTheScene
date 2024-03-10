using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemacinePOVExtension : CinemachineExtension
{

    [SerializeField] private float clampAngle = 80f;

    [SerializeField] private float horizontalSpped = 10f;
    [SerializeField] private float verticalSpeed = 10f;
    private InputManager inputManager;

    private Vector3 startingRotation;

    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == Cinemachine.CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = inputManager.GetMouseDelta();
                startingRotation.x += deltaInput.x*verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpped * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);

                state.RawOrientation = Quaternion.Euler(startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

}
