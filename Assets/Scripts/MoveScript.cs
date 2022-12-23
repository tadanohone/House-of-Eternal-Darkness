using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // アニメーション
    Animator anim;

    // 移動
    Rigidbody _rb;
    public bool isUseCameraDirection;    // カメラの向きに合わせて移動させたい場合はtrue
    public float moveSpeed;              // 移動速度
    public float moveForceMultiplier;    // 移動速度の入力に対する追従度
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;
    public GameObject Avatar;

    // 向き
    private Vector3 latestPos;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // 移動
        Vector3 moveVector = Vector3.zero;    // 移動速度の入力

        if (isUseCameraDirection)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0.0f;    // 水平方向に移動させたい場合はy方向成分を0にする
            cameraRight.y = 0.0f;

            moveVector = moveSpeed * (cameraRight.normalized * _horizontalInput + cameraForward.normalized * _verticalInput);
        }
        else
        {
            moveVector.x = moveSpeed * _horizontalInput;
            moveVector.z = moveSpeed * _verticalInput;
        }
        _rb.AddForce(moveVector);
        _rb.AddForce(moveVector);

        // 向き
        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;

        if (diff.magnitude > 0.01f)
        {
            Avatar.transform.rotation = Quaternion.LookRotation(diff);
        }
    }
}