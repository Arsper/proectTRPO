using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaySystem : MonoBehaviour
{
    private Invertory invertory;
    public Transform raypoint;
    public float usingdistantion = 1.75f;
    private GameObject slot;
    public GameObject LockCamera;
    RaycastHit hit;
    
    public Text info;
    public Text helpText;

    void Start() 
    {
        invertory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invertory>();
    }

    void LateUpdate()
    {
        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, usingdistantion))
        {
            if (hit.collider.tag == "Untagged")
            {
                info.text = null;
            }

            if (hit.collider.tag == "Item")
            {
                info.text = hit.collider.name +" (ЛКМ поднять, E бросить)";
            }

            if(hit.collider.tag == "door")
            {
                info.text = "дверь";

                if (Input.GetMouseButtonDown(0))
                {
                    try
                    {
                        slot = GameObject.Find($"Slot ({invertory.numSlot + 1})");
                        foreach (Transform child in slot.transform)
                        {
                            if (child.name=="KeyInMenu(Clone)")
                            {
                                Door door = hit.collider.GetComponent<Door>();
                                door.Using();
                                break;
                            }
                        }
                    }
                    catch 
                    {
                    }
                    
                }
            }
            if (hit.collider.tag == "Lock" && !LockCamera.activeSelf)
            {
                info.text = "Замок (нажмите Q)";
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    LockCamera.SetActive(true);
                    info.text = null;
                    helpText.text = "TAB-Выйти\r\n1-изминения первой ячейки\r\n2-изминения второй ячейки\r\n3-изминения третей ячейки";
                }
            }
        }
        else
        {
            info.text = "";
        }
    }

}
