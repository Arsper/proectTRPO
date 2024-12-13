using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyBind : MonoBehaviour
{
    // Start is called before the first frame update

    UnityEngine.UI.Text KeyBindText = null;

    public void setKey(UnityEngine.UI.Text pressedKey)
    {
        KeyBindText = pressedKey;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(KeyBindText != null)
        {
            if(Input.GetKey(Event.KeyboardEvent(Input.inputString).keyCode))
            {
                KeyBindText.text = Input.inputString;
                KeyBindText = null;
            }
        }

    }
}
