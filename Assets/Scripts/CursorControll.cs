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
        // Проверка, нажимается ли на UI элемент
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Если нажимается на UI элемент, то курсор не скрывается
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Если не нажимается на UI элемент, то скрываем курсор
            if (Input.GetMouseButtonDown(0)) // Проверяем левую кнопку мыши
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

