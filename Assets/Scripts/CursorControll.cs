using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��������, ���������� �� �� UI �������
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // ���� ���������� �� UI �������, �� ������ �� ����������
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // ���� �� ���������� �� UI �������, �� �������� ������
            if (Input.GetMouseButtonDown(0)) // ��������� ����� ������ ����
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

