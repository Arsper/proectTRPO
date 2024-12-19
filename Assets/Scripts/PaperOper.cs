using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperOper : MonoBehaviour
{
    public GameObject PaperInfo;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PaperInfo.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
        }
    }
}
