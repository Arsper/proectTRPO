using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shelve : MonoBehaviour
{
    public Transform raypoint;
    public float usingDistance = 1.75f;
    public GameObject drawer;
    public Vector3 openPosition;
    public Vector3 closedPosition;
    public float drawerSpeed = 3.0f;
    private bool isDrawerOpen = false;
    public Text info;

    void Start()
    {
        closedPosition = drawer.transform.localPosition;
        openPosition = closedPosition + new Vector3(0, 0, 0.5f);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, usingDistance))
        {
            if (hit.collider.gameObject == drawer)
            {
                info.text = "Полка (E открыть, Q закрыть)";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleDrawer(true);
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    ToggleDrawer(false);
                }
            }
        }
        else
        {
            info.text = "";
        }

        if (isDrawerOpen)
        {
            drawer.transform.localPosition = Vector3.Lerp(drawer.transform.localPosition, openPosition, Time.deltaTime * drawerSpeed);
        }
        else
        {
            drawer.transform.localPosition = Vector3.Lerp(drawer.transform.localPosition, closedPosition, Time.deltaTime * drawerSpeed);
        }
    }

    void ToggleDrawer(bool open)
    {
        isDrawerOpen = open;
    }
}
