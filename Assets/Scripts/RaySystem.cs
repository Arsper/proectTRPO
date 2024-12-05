using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaySystem : MonoBehaviour
{
    public Transform raypoint;
    public float usingdistantion = 1.75f;
    RaycastHit hit;

    public Text info;

    void LateUpdate()
    {
        if (Physics.Raycast(raypoint.position, raypoint.forward, out hit, usingdistantion))
        {
            if (hit.collider.tag == "Untagged")
            {
                info.text = null;
            }

            if (hit.collider.tag == "cube")
            {
                info.text = "cube";
            }
        }
        else
        {
            info.text = null;
        }
    }

}
