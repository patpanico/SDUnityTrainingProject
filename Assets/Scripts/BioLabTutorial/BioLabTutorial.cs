using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioLabTutorial : MonoBehaviour
{
    public GameObject levelBeaker;
    public GameObject LabCompletedUI;
    public GameObject LabFailedUI;
    public GameObject PopupUI;
    Text TutorialText;
    int step = 0;
    int salt = 0;
    float waterTimer = 10;
    int waterStage = 0;

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
                step++;
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
                TutorialText.text = "Begin by placing 0 to 2 of the 1g salt cubes into the beaker with 100mL of water. When finished, press Spacebar.";
            }
            else if (step == 4) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
                TutorialText.text = "Now place the potato in the beaker and let it sit for 10 seconds.";
            }
            else if (step == 7) {
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
                LabCompletedUI.GetComponent<LabCompleted>().Completed();
            }
        if (step == 6) {
            if (waterTimer >= 0) {
                waterTimer -= Time.deltaTime;
                if (waterTimer <= 6 && waterStage == 0) {
                    waterStage++;
                    if (salt == 2) {
                        levelBeaker.transform.Find("Potato").gameObject.SetActive(false);
                        levelBeaker.transform.Find("SmallPotato1").gameObject.SetActive(true);
                    }
                    else if (salt == 0)
                    {
                        levelBeaker.transform.Find("SmallPotato1").gameObject.SetActive(true);
                        levelBeaker.transform.Find("LargePotato1").gameObject.SetActive(true);
                    }
                }
                else if (waterTimer <= 2 && waterStage == 1) {
                    waterStage++;
                    if (salt == 2) {
                        levelBeaker.transform.Find("SmallPotato1").gameObject.SetActive(false);
                        levelBeaker.transform.Find("SmallPotato2").gameObject.SetActive(true);
                    }
                    else if (salt == 0) {
                        levelBeaker.transform.Find("LargePotato1").gameObject.SetActive(false);
                        levelBeaker.transform.Find("LargePotato2").gameObject.SetActive(true);
                    }
                }
            }
            else {
                step++;
                TutorialText.text = "";
                if (salt == 0) {
                    PopupUI.GetComponent<TutorialPopup>().OpenPopup("Since 0 salt cubes were placed into the water, the solution in the beaker was hypotonic relative to the potato and the potato gained water through osmosis as expected.");
                }
                else if (salt == 1) {
                    PopupUI.GetComponent<TutorialPopup>().OpenPopup("Since 1 salt cube was placed into the water, the solution in the beaker was isotonic relative to the potato and the potato did not change in size as expected.");
                }
                else if (salt == 2) {
                    PopupUI.GetComponent<TutorialPopup>().OpenPopup("Since 2 salt cubes were placed into the water, the the solution in the beaker was hypertonic relative to the potato and the potato lost water by osmosis as expected.");
                }
            }
        }
    }

    public void CheckObject(GameObject obj)
    {
        if (obj.name == "SaltCube" && step == 4) {
            salt++;
            Destroy(obj);
        }
        else if (obj.name == "Potato" && step == 5) {
            step++;
            Destroy(obj);
            levelBeaker.transform.Find("Potato").gameObject.SetActive(true);
            levelBeaker.transform.Find("Beaker").gameObject.transform.Find("4").gameObject.SetActive(false);
            levelBeaker.transform.Find("Beaker").gameObject.transform.Find("3").gameObject.SetActive(true);
        }
        else {
            LabFailedUI.GetComponent<LabFailed>().Failed();
        }
    }
}
