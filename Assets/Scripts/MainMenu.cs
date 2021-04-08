using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BiologyButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ChemistryButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
