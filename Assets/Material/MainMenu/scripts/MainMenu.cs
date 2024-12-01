using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//подключение библиотеки для перехода между сценами

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
        SceneManager.LoadScene("GamePlay"); // загрузка сцены GamePlay
    }

    public void Options()
    {
        Debug.Log("Настройки"); 
    }

    public void Quitgame()
    {
        Application.Quit(); // выход из игры
        Debug.Log("Игра закрыта");
    }
}
