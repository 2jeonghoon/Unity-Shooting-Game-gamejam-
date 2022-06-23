using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveForce;

    [SerializeField]
    private float jumpForce; // ���� ��
    [SerializeField]
    private float gravity; // �߷� ���

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        // ����� �������� �߷¸�ŭ y�� �̵��ӵ� ����
        if (!characterController.isGrounded) // isGrounded ���ӿ�����Ʈ�� ���� �ٴڰ� �浹�ϸ� true ��ȯ
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        // 1�ʴ� moveForce �ӷ����� �̵�
        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        // �÷��̾ �ٴڿ� ���� ���� ���� ����
        if(characterController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }
}