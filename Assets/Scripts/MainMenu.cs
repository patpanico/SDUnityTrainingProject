using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BiologyButton()
    {
        SceneManager.LoadScene("ChemLabTutorial");
    }

    public void ChemistryButton()
    {
        SceneManager.LoadScene("ChemLabTutorial");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
