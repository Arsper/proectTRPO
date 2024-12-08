using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public int numSlot = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            numSlot = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            numSlot = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            numSlot = 2; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            numSlot = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            numSlot = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            numSlot = 5;
        }
    }
}   
