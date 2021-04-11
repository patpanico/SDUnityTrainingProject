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
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("In this tutorial you will learn how\nto separate a mixture of two\nliquids using distillation.");
            }
            else if (step == 1) {
                step++;
                PopupUI.GetComponent<TutorialPopup>().OpenPopup("The wide flask contains the mixture...");
            }
            else if (step == 2) {
                PopupUI.GetComponent<TutorialPopup>().ClosePopup();
                step++;
                TutorialText.text = "Begin by putting the mixture in the wide flask onto the stand directly above the heating source...";
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
            else if (step == 7)
            {
                step++;
                TutorialText.text = "Turn off the heat source now that it is at 100 degress fahrenheit...\n\n(Warning: Running mixture under heat for too long (until dry) could create a safety hazard)";
                GameObject.Find("DripSystem").GetComponent<ParticleSystem>().enableEmission = false;

                levelDistiller.transform.Find("Flask4").gameObject.transform.Find("3").gameObject.SetActive(false);
                levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("3").gameObject.SetActive(false);
                levelDistiller.transform.Find("Flask3").gameObject.transform.Find("2").gameObject.SetActive(false);

                levelDistiller.transform.Find("Flask4").gameObject.transform.Find("4").gameObject.SetActive(true);
                levelDistiller.transform.Find("Thermometer").gameObject.transform.Find("4").gameObject.SetActive(true);
                levelDistiller.transform.Find("Flask3").gameObject.transform.Find("3").gameObject.SetActive(true);
            }
            else if (step == 8) {
                failTimer -= Time.deltaTime;
                if (failTimer <= 2.5 && failStage == 0) {
                    failStage++;
                    GameObject.Find("GasSystem").GetComponent<ParticleSystem>().enableEmission = true;
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
        if (obj.name == "Flask4" && step == 3) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Connect the distilling head to the tip of the wide flask, making sure the connection is air-tight...";
        }
        else if (obj.name == "Distiller Head" && step == 4) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Place the empty graduated cylinder under the distilling head...";
        }
        else if (obj.name == "Flask3" && step == 5) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Put the thermometer in the top-end of the distilling head, making sure the connection is air-tight...";
        }
        else if (obj.name == "Thermometer" && step == 6)
        {
            ActivateDestroyStepUp(obj);
            levelDistiller.transform.Find("Rubber Connector").gameObject.SetActive(true);
            TutorialText.text = "Turn on the heat source and wait for the mixture to seperate into the graduated cylinder...";
        }
    }

    public bool IsHeatReady()
    {
        return (step == 7);
    }

    public bool IsHeatReadyToOff()
    {
        return (step == 8);
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
