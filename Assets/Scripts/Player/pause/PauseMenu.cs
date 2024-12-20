using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isCursorLocked = false;

    public bool pauseGame;

    public GameObject pauseMenu;

    public GameObject pauseButton;

    public GameObject resumeButton;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGame)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                LoadMenu();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (pauseGame)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
                Resume();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = false;
                Pause();
                
            }
        }
    }

    public void Resume()
    {

        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }

    public void Pause()
    {
        
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        resumeButton.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
