using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RaySystem : MonoBehaviour
{
    private Invertory invertory;
    private Flashlight flashlight;
    public Transform raypoint;
    public float usingdistantion = 1.75f;
    private GameObject slot;
    public GameObject mainCamera;
    RaycastHit hit;
    
    public Text info;
    public Text helpText;

    void Start() 
    {
        invertory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invertory>();
        mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().mainCamera;
        flashlight = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Flashlight>();
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
                info.text = hit.collider.name +" (E поднять, Q бросить)";
            }

            if(hit.collider.tag == "door")
            {
                info.text = "дверь(E открыть)";

                if (Input.GetKeyDown(KeyCode.E))
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
            if (hit.collider.tag == "Lock" && mainCamera.activeSelf)
            {
                info.text = "Замок (нажмите E)";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject key = hit.collider.GameObject();
                    key.GetComponent<LockControl>().VirtualCam.SetActive(true);
                    flashlight.canLight = false;
                    mainCamera.SetActive(false);
                    info.text = null;
                    helpText.text = "Q-Выйти\r\n1-изминения первой ячейки\r\n2-изминения второй ячейки\r\n3-изминения третей ячейки";
                }
            }
        }
        else
        {
            info.text = "";
        }
    }

}
