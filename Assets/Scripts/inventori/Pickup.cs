using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picup : MonoBehaviour
{
    private Invertory invertory;
    public GameObject slotButton;
    private Transform raypoint;
    RaycastHit hit;

    public void Start()
    {
        invertory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invertory>();
        raypoint = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void AddItemToInventory()
    {
        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, 1.75f))
        {
            if (hit.collider.tag == "Item" && Input.GetKeyDown(KeyCode.E))
            {
                if (invertory.numSlot>=0)
                {
                    if (invertory.isFull[invertory.numSlot] == false)
                    {
                        invertory.isFull[invertory.numSlot] = true;
                        Instantiate(slotButton, invertory.slots[invertory.numSlot].transform);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Console.WriteLine("€чейка занета");
                    }
                }
            }
        }
    }
    void LateUpdate()
    {
        AddItemToInventory();
    }
}
