using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioLabTutorial : MonoBehaviour
{
    public GameObject LabCompletedUI;
    public GameObject PopupUI;
    Text TutorialText;
    int step = 0;

    void Start()
    {
        TutorialText = GameObject.Find("TutorialText").GetComponent<Text>();
        PopupUI.GetComponent<TutorialPopup>().OpenPopup("Welcome to the\nBiology Lab Tutorial!");
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            if (step == 0) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
            }
    }
}