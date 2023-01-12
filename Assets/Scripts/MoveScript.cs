using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // �A�j���[�V����
    Animator anim;

    // �ړ�
    Rigidbody _rb;
    public bool isUseCameraDirection;    // �J�����̌����ɍ��킹�Ĉړ����������ꍇ��true
    public float moveSpeed;              // �ړ����x
    public float moveForceMultiplier;    // �ړ����x�̓��͂ɑ΂���Ǐ]�x
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;
    public GameObject Avatar;

    // ����
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
        // �ړ�
        Vector3 moveVector = Vector3.zero;    // �ړ����x�̓���

        if (isUseCameraDirection)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;
            cameraForward.y = 0.0f;    // ���������Ɉړ����������ꍇ��y����������0�ɂ���
            cameraRight.y = 0.0f;

            moveVector = moveSpeed * (cameraRight.normalized * _horizontalInput + cameraForward.normalized * _verticalInput);
        }
        else
        {
            moveVector.x = moveSpeed * _horizontalInput;
            moveVector.z = moveSpeed * _verticalInput;
        }
        if (_rb.velocity.magnitude < 10.0f)
        {
            _rb.AddForce(moveForceMultiplier * (moveVector - _rb.velocity)); // �͂�������
        }

        // ����
        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;

        if (diff.magnitude > 0.01f)
        {
            Avatar.transform.rotation = Quaternion.LookRotation(diff);
        }
    }
}