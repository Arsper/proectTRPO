using UnityEngine;
using UnityEngine.UI;

public class TextHoverEffect : MonoBehaviour
{
    public Text text;
    public Color originalColor;

    void Start()
    {
        text = GetComponent<Text>();
        originalColor = text.color;
    }

    public void OnMouseEnter()
    {
        text.color = Color.red;
    }

    public void OnMouseExit()
    {
        text.color = originalColor;
    }
}
