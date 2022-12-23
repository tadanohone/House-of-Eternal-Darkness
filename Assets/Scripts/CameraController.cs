using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Vector2 rotationSpeed = new Vector2(180, 180);

    CinemachineVirtualCamera vCam = null;
    Cinemachine3rdPersonFollow follow = null;

    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        if(vCam != null)
        {
            follow = vCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        }
    }

    void FixedUpdate()
    {
        if (vCam != null)
        {
            Transform target = vCam.Follow;
            if (target != null)
            {
                Vector3 targetEulerAngles = target.rotation.eulerAngles;
                targetEulerAngles.y += cameraRotationInput.x * rotationSpeed.y * Time.fixedDeltaTime;
                target.transform.rotation = Quaternion.Euler(targetEulerAngles);
            }
        }
    }

    Vector2 cameraRotationInput = Vector2.zero;

    void Look(Vector2 input)
    {
        cameraRotationInput = input;
    }

    void OnLook(InputValue inputValue)
    {
        Look(inputValue.Get<Vector2>());
    }
}
