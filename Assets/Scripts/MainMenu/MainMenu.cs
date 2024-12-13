using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//����������� ���������� ��� �������� ����� �������
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    public GameObject OptionsObject;
    int switchImage = 0;


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
        SceneManager.LoadScene("SceneWithActions"); // �������� ����� GamePlay
    }

    public void Options()
    {
        OptionsObject.SetActive(true); 
    }

    public void Quitgame()
    {
        Application.Quit(); // ����� �� ����
        Debug.Log("���� �������");
    }
}
