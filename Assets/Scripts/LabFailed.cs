using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabFailed : MonoBehaviour
{
    public GameObject CrosshairObj;
    public static bool isFailed;

    public void Failed()
    {
        isFailed = true;
        this.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CrosshairObj.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("ChemLabTutorial");
    }
}
