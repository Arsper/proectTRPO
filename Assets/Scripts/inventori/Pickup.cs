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
    void LateUpdate()
    {
        if(Physics.Raycast(raypoint.position, raypoint.forward, out hit, 1.75f))
        {
            if (hit.collider.tag == "Item" && Input.GetMouseButtonDown(0))
            {
                for (int i = 0; invertory.slots.Length > 0; i++)
                {
                    if (invertory.isFull[i] == false)
                    {
                        invertory.isFull[i] = true;
                        Instantiate(slotButton, invertory.slots[i].transform);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
}
