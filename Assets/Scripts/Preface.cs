using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preface : MonoBehaviour
{

    public Text storyText;
    public string fullText;
    public float typingSpeed = 0.05f;
    public Text startButton;
    public AudioSource audioSource;

    private string currentText = "";

    void Start()
    {
        startButton.gameObject.SetActive(false);
        audioSource.loop = true;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        audioSource.Play();
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            storyText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        audioSource.Stop();
        startButton.gameObject.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void x3()
    {
        typingSpeed = typingSpeed/3f;
    }
    public void skip()
    {
        StopAllCoroutines();
        storyText.text = fullText;
        startButton.gameObject.SetActive(true);
    }
}
