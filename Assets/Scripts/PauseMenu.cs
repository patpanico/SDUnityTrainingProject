using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuObj;
    public GameObject CrosshairObj;
    public static bool isPaused;

    void Start()
    {
        PauseMenuObj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuObj.SetActive(true);
        CrosshairObj.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuObj.SetActive(false);
        CrosshairObj.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
