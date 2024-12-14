using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private float sensitivity;
    private float mouseX;
    private float mouseY;

    [SerializeField] private Vector2 clampangle;
    private Vector2 angle;

    [SerializeField] private GameObject myLight;

    private GameObject mainCamera;
    public bool canLight = true;
    private Light light;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().mainCamera;
        light = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (canLight && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove)
        {
            HandleMovement();
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }

    }

    private void HandleMovement() 
    {

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        angle.x -= mouseY * sensitivity;
        angle.y -= mouseX * -sensitivity;

        angle.x = Mathf.Clamp(angle.x, -clampangle.x, clampangle.y);

        Quaternion rotation = Quaternion.Euler(angle.x, angle.y, 0.0f);
        Quaternion rotationTwo = Quaternion.Euler(0.0f, angle.y, 0.0f);
        transform.rotation = rotationTwo;
        myLight.transform.rotation = rotation;
    }

}
