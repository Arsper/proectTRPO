using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour
{
    private Invertory invertory;
    private GameObject slot;
    public static string dropButton = "q";

    public void Start()
    {
        invertory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invertory>();
        
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(dropButton))
        {
            try
            {
                slot = GameObject.Find($"Slot ({invertory.numSlot + 1})");
                foreach (Transform child in slot.transform)
                {
                    child.GetComponent<Spawn>().SpawnDropperItem();
                    Destroy(child.gameObject);
                    invertory.isFull[invertory.numSlot] = false;
                    break;
                }
            }
            catch
            {
            }
        }
    }
}
