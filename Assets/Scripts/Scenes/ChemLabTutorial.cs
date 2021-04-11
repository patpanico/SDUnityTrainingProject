using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemLabTutorial : MonoBehaviour
{
    public GameObject levelDistiller;
    public GameObject LabCompletedUI;
    public GameObject LabFailedUI;
    public GameObject PopupUI;
    Text TutorialText;
    int step = 0;
    bool isHeatOn;
    float heatTimer = 10;
    int heatStage = 0;
    float failTimer = 5;
    int failStage = 0;

    void Start()
    {
        TutorialText = GameObject.Find("TutorialText").GetComponent<Text>();
        PopupUI.GetComponent<TutorialPopup>().OpenPopup("Welcome to the\nChemistry Tutorial Lab!");
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            if (step == 0) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("In this tutorial you will learn how to separate a mixture of two liquids via distillation, or by using heat. Distillation takes advantage of the fact that different liquids have different boiling points.");
            }
            else if (step == 1) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("When a liquid changes phase to a gas, it will leave the flask. But as long as it stays a liquid, it will stay in the flask. So if a temperature is maintained where one substance in the mixture will boil but the other will not, then the mixture will become separated.");
            }
            else if (step == 2) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("In this tutorial, you will start with a Cyclohexane-Toluene mixture already contained in a round bottomed flask. The substances are colored for clarity, and are not necessarily realistic.");
            }
            else if (step == 3) {
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
                step++;
                TutorialText.text = "Begin by putting the mixture in the wide flask onto the stand directly above the heating source.";
            }
        }

        if (isHeatOn) {
            if (heatTimer > 0)
            {
                heatTimer -= Time.deltaTime;
                if (heatTimer <= 6.66 && heatStage == 0)
                {
                    heatStage++;

                    levelDistiller.transform.Find("Flask4").gameObject.transform.Find("1").gameObject.SetActive(false);
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("1").gameObject.SetActive(false);

                    levelDistiller.transform.Find("Flask4").gameObject.transform.Find("2").gameObject.SetActive(true);
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("2").gameObject.SetActive(true);
                    levelDistiller.transform.Find("Flask3").gameObject.transform.Find("1").gameObject.SetActive(true);
                }
                else if (heatTimer <= 3.33 && heatStage == 1)
                {
                    heatStage++;

                    levelDistiller.transform.Find("Flask4").gameObject.transform.Find("2").gameObject.SetActive(false);
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("2").gameObject.SetActive(false);
                    levelDistiller.transform.Find("Flask3").gameObject.transform.Find("1").gameObject.SetActive(false);

                    levelDistiller.transform.Find("Flask4").gameObject.transform.Find("3").gameObject.SetActive(true);
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("3").gameObject.SetActive(true);
                    levelDistiller.transform.Find("Flask3").gameObject.transform.Find("2").gameObject.SetActive(true);
                }
            }
            else if (step == 8)
            {
                step++;
                TutorialText.text = "Turn off the heat source now that the vapor is at 111 degrees Celsius.\n\n(Warning: Running mixture under heat for too long, i.e. until dry, could result in the accumulation of explosive substances)";
                GameObject.Find("DripSystem").GetComponent<ParticleSystem>().enableEmission = false;

                levelDistiller.transform.Find("Flask4").gameObject.transform.Find("3").gameObject.SetActive(false);
                levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("3").gameObject.SetActive(false);
                levelDistiller.transform.Find("Flask3").gameObject.transform.Find("2").gameObject.SetActive(false);

                levelDistiller.transform.Find("Flask4").gameObject.transform.Find("4").gameObject.SetActive(true);
                levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("4").gameObject.SetActive(true);
                levelDistiller.transform.Find("Flask3").gameObject.transform.Find("3").gameObject.SetActive(true);
            }
            else if (step == 9) {
                failTimer -= Time.deltaTime;
                if (failTimer <= 2.5 && failStage == 0) {
                    failStage++;
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("4").gameObject.SetActive(false);
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("5").gameObject.SetActive(true);
                }
                else if (failTimer <= 0) {
                    step++;
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("5").gameObject.SetActive(false);
                    levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("6").gameObject.SetActive(true);
                    TutorialText.text = "";
                    LabFailedUI.GetComponent<LabFailed>().Failed();
                }
            }
        }
    }

    void ActivateDestroyStepUp(GameObject obj)
    {
        levelDistiller.transform.Find(obj.name).gameObject.SetActive(true);
        Destroy(obj);
        step++;
    }

    public void CheckObject(GameObject obj)
    {
        if (obj.name == "Flask4" && step == 4) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "The distilling head is an apparatus which boiled vapors will pass through, condense when far enough away from the heat source, and then drip through the slanted end. Connect the distilling head to the tip of the wide flask, making sure the connection is air-tight so no vapor escapes.";
        }
        else if (obj.name == "Distiller Head" && step == 5) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "As the vapor condenses and drips out of the distilling head, we will use a graduated cyllinder to collect the liquid. Now place the empty graduated cylinder under the distilling head.";
        }
        else if (obj.name == "Flask3" && step == 6) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Now put the thermometer in the top-end of the distilling head, making sure the connection is air-tight so no vapor escapes. We will use the thermometer to gauge when our system is no longer at a temperature strictly between the two boiling points.";
        }
        else if (obj.name == "Thermometer" && step == 7)
        {
            ActivateDestroyStepUp(obj);
            levelDistiller.transform.Find("Rubber Connector").gameObject.SetActive(true);
            TutorialText.text = "Turn on the heat source and wait for the mixture to seperate into the graduated cylinder. Cyclohexane's boiling point is 81 degrees Celsius whereas Toluene's boiling point is 111 degrees Celsius, so as long as the system stays comfortably between 81 and 111 Celsius, Cyclohexane will boil and Toluene will not.";
        }
    }

    public bool IsHeatReady()
    {
        return (step == 8);
    }

    public bool IsHeatReadyToOff()
    {
        return (step == 9);
    }

    public void TurnOnHeat()
    {
        isHeatOn = true;
        GameObject.Find("DripSystem").GetComponent<ParticleSystem>().enableEmission = true;
    }

    public void TurnOffHeat()
    {
        isHeatOn = false;

        TutorialText.text = "";
        LabCompletedUI.GetComponent<LabCompleted>().Completed();
    }
}
