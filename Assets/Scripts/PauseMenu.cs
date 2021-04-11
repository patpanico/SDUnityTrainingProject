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
        if (Input.GetKeyDown(KeyCode.Escape) && !(LabCompleted.isCompleted || LabFailed.isFailed))
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
        isPaused = false;
        PauseMenuObj.SetActive(false);
        if (!TutorialPopup.isPopup) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CrosshairObj.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void MenuButton()
    {
        isPaused = false;
        TutorialPopup.isPopup = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
