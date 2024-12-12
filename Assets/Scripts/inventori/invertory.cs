using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Invertory : MonoBehaviour
{

    public bool[] isFull;

    public GameObject[] slots;

    public int numSlot = -1;

    private GameObject slot;
    private GameObject mainCamera;

    Animator anim;

    private KeyCode lastKeyPressed;


    private void Update()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().mainCamera;
        if (mainCamera.activeSelf)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key) && key >= KeyCode.Alpha1 && key <= KeyCode.Alpha6)
                {
                    lastKeyPressed = key; 
                    Debug.Log($"Нажата клавиша: {lastKeyPressed}");
                    break;
                }
            }

            if (Input.GetKeyDown($"{lastKeyPressed}"))
            {

                PlayAnims(Convert.ToInt32(lastKeyPressed));

            }
            //if (Input.GetKeyDown($"2"))
            //{

            //    PlayAnims(1);

            //}
            //if (Input.GetKeyDown($"3"))
            //{

            //    PlayAnims(2);

            //}
            //if (Input.GetKeyDown($"4"))
            //{

            //    PlayAnims(3);

            //}
            //if (Input.GetKeyDown($"5"))
            //{

            //    PlayAnims(4);

            //}
            //if (Input.GetKeyDown($"6"))
            //{

            //    PlayAnims(5);

            //}
        }
    }

    public void PlayAnims(int newNumSlot)
    {
        if (numSlot>=0)
        {
            slot = GameObject.Find($"Slot ({numSlot + 1})");
            anim = slot.GetComponent<Animator>();
            anim.Play("Disabled");
        }
        if (numSlot!=newNumSlot)
        {
            numSlot = newNumSlot;

            slot = GameObject.Find($"Slot ({numSlot + 1})");
            anim = slot.GetComponent<Animator>();
            anim.Play("Selected");
        }
        else
        {
            numSlot = -1;
        }
        
    }
}   
