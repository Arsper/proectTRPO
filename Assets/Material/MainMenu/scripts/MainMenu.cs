using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//����������� ���������� ��� �������� ����� �������

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay"); // �������� ����� GamePlay
    }

    public void Options()
    {
        Debug.Log("���������"); 
    }

    public void Quitgame()
    {
        Application.Quit(); // ����� �� ����
        Debug.Log("���� �������");
    }
}
