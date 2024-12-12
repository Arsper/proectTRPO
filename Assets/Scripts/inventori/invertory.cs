using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Invertory : MonoBehaviour
{

    public bool[] isFull;

    public GameObject[] slots;

    public int numSlot = 0;

    private GameObject slot;
    private GameObject mainCamera;

    Animator anim;

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().mainCamera;
        if (mainCamera.activeSelf)
        {

            for(int i =0; i < slots.Length;i++)
            {
                if (Input.GetKeyDown((i+1).ToString()))
                {

                    PlayAnims(i);

                }

            }

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
