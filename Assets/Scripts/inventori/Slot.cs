using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Invertory invertory;
    public int i;

    public void Start()
    {
        invertory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invertory>();
    }
    private void Update()
    {
        if (transform.childCount <=0)
        {
            invertory.isFull[i] = false;
        }
        if (Input.GetKeyDown("space"))
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnDropperItem();
                Destroy(child.gameObject);
                break;
            }
        }
    }
}
