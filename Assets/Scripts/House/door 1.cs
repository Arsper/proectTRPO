using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDoor : MonoBehaviour
{
    public Transform raypoint;
    public float usingDistance = 1.75f;
    public GameObject door; // Родительский объект двери
    public float openAngle; // Угол открытия двери
    public float doorSpeed = 3.0f; // Скорость движения двери
    private bool isDoorOpen = false; // Состояние двери (открыта/закрыта)
    public Text info; // UI текст для отображения информации

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Сохранение начального поворота двери
        closedRotation = door.transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0); // Настройка поворота открытия
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, usingDistance))
        {
            if (hit.collider.gameObject == door)
            {
                info.text = "Дверь (E открыть, Q закрыть)";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleDoor(true);
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    ToggleDoor(false);
                }
            }
        }
        else
        {
            info.text = "";
        }

        // Плавное движение двери
        if (isDoorOpen)
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openRotation, Time.deltaTime * doorSpeed);
        }
        else
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, closedRotation, Time.deltaTime * doorSpeed);
        }
    }

    void ToggleDoor(bool open)
    {
        isDoorOpen = open;
    }
}
