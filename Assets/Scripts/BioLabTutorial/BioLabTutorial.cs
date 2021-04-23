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
    int salt = 0;

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
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("In this tutorial you will learn how plants consume water. Plant roots work by taking advantage of osmosis, which is when water molecules move from one location to a new location of higher soluble concentration to balance out the solute concentration.");
            }
            else if (step == 1) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("When the plant's roots have a higher concentration of solubles than the surrounding water, the water molecules then move into the roots which have a higher solute concentration.");
            }
            else if (step == 2) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("In this tutorial, you will start with a potato, which is the root of its respective plant, and place it into solutions of varying salt concentration.");
            }
            else if (step == 3) {
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
                step++;
                TutorialText.text = "Begin by placing 0 to 2 of the 1g salt cubes into the beaker with 100mL of water. When finished, press the spacebar.";
            }
            else if (step == 4) {
                step++;
                if (salt == 0) {
                    PopupUI.GetComponent<TutorialPopup>().OpenPopup("If 0 salt cubes were placed into the water, then the solution in the beaker is hypotonic relative to the potato and the potato will gain water through osmosis.");
                }
                else if (salt == 1) {
                    PopupUI.GetComponent<TutorialPopup>().OpenPopup("If 1 salt cubes were placed into the water, then the solution in the beaker is isotonic relative to the potato and the potato will not change in size.");
                }
                else if (salt == 2) {
                    PopupUI.GetComponent<TutorialPopup>().OpenPopup("If 2 salt cubes were placed into the water, then the solution in the beaker is hypertonic relative to the potato and the potato will lose water by osmosis.");
                }
            }
            else if (step == 5) {
                step++;
                TutorialText.text = "Now place the potato in the beaker and let it sit for 20 minutes.";
            }
    }

    public void CheckObject(GameObject obj)
    {
        if (obj.name == "SaltCube" && step == 3) {
            Destroy(obj);
            salt++;
        }
        else if (obj.name == "Potato" && step == 5) {
            
        }
    }
}
