using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movespeed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float gravity;
    private float mouseX;
    private float mouseY;
    private float vertical;
    private float horizontal;

    [SerializeField] private Vector2 clampangle;
    private Vector3 Velocity;
    private Vector2 angle;

    public GameObject mainCamera;

    private CharacterController charactercontroller;

    private Animator animator;

    private void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (mainCamera.activeSelf)
        {
            HandleMovement();
        }
    }

    private void HandleMovement() 
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 playerMovementInput = new Vector3(horizontal, 0.0f, vertical);
        Vector3 moveVector = transform.TransformDirection(playerMovementInput);

        if (vertical > 0 || vertical < 0 || horizontal > 0 || horizontal < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && vertical > 0)
            {
                movespeed = 6;
                animator.SetInteger("Move", 2);
            }
            else
            {
                movespeed = 2f;
                animator.SetInteger("Move", 1);

            }
        }
        else
        {
            animator.SetInteger("Move", 0);
        }

        if (charactercontroller.isGrounded)
        {
            Velocity.y = -1f;
        }
        else
        {
            Velocity.y -= gravity * Time.deltaTime;
        }

        charactercontroller.Move(moveVector * movespeed * Time.deltaTime);
        charactercontroller.Move(Velocity * Time.deltaTime);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        angle.x -= mouseY * sensitivity;
        angle.y -= mouseX * -sensitivity;

        angle.x = Mathf.Clamp(angle.x, -clampangle.x, clampangle.y);

        Quaternion rotation = Quaternion.Euler(angle.x, angle.y, 0.0f);
        Quaternion rotationTwo = Quaternion.Euler(0.0f, angle.y, 0.0f);
        transform.rotation = rotationTwo;
        mainCamera.transform.rotation = rotation;
    }
}
