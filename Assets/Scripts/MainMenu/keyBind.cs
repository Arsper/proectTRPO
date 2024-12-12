using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyBind : MonoBehaviour
{
    // Start is called before the first frame update

    UnityEngine.UI.Text tst = null;

    public void setKey(UnityEngine.UI.Text ts)
    {
        tst = ts;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(tst != null)
        {
            if(Input.GetKey(Event.KeyboardEvent(Input.inputString).keyCode))
            {
                tst.text = "Key: " + Input.inputString;
                tst = null;
            }
        }

    }
}
