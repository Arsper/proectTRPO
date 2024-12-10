using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool coroutineAllowed;
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    private GameObject mainCamera;
    private RaySystem rayS;
    public GameObject VirtualCam;
    private void Start()
    {
        result = new int[] { 5, 5, 5 };
        correctCombination = new int[] { 3, 7, 9 };
        rayS = GameObject.FindGameObjectWithTag("Player").GetComponent<RaySystem>();
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().mainCamera;
    }
    private void Update()
    {
        if (!mainCamera.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(RotateWheel(wheel1,0));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(RotateWheel(wheel2,1));
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(RotateWheel(wheel3,2));
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                mainCamera.SetActive(true);
                VirtualCam.SetActive(false);
                rayS.helpText.text = "";
            }
        }
    }
    private IEnumerator RotateWheel(GameObject wheel,int numRes)
    {
        coroutineAllowed = false;
        for (int i = 0; i <= 11; i++)
        {
            wheel.transform.Rotate(0f, 0f, -3f);
            yield return new WaitForSeconds(0.001f);
        }
        coroutineAllowed = true;
        result[numRes] += 1;
        if (result[numRes] > 9)
        {
            result[numRes] = 0;
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            Debug.Log("Opened!");
            mainCamera.SetActive(true);
            VirtualCam.SetActive(false);
            rayS.helpText.text = "";
        }
    }
}
