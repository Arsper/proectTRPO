using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory : MonoBehaviour
{
    public bool[] isFull;

    public GameObject[] slots;

    public int numSlot = -1;

    private GameObject slot;
    private GameObject mainCamera;

    Animator anim;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().mainCamera;
    }
    private void Update()
    {
        if (mainCamera.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                PlayAnims(0);

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                PlayAnims(1);

            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                PlayAnims(2);

            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                PlayAnims(3);

            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {

                PlayAnims(4);

            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {

                PlayAnims(5);

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
