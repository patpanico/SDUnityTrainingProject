using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemLabTutorial : MonoBehaviour
{
    Text TutorialText;
    public GameObject levelDistiller;
    int step = 0;

    void Start()
    {
        TutorialText = GameObject.Find("TutorialText").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && step == 0) {
            step++;
            TutorialText.text = "Begin by putting the mixture in the wide flask onto the stand directly above the heating source...";
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
        if (obj.name == "Flask4" && step == 1) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Connect the distilling head to the tip of the wide flask, making sure the connecting is air-tight...";
        }
        else if (obj.name == "Distiller Head" && step == 2) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Place the empty graduated cylinder under the distilling head...";
        }
        else if (obj.name == "Flask3" && step == 3) {
            ActivateDestroyStepUp(obj);
            TutorialText.text = "Put the thermometer in the top-end of the distilling head, making sure the connecting is air-tight...";
        }
        else if (obj.name == "Thermometer" && step == 4)
        {
            ActivateDestroyStepUp(obj);
            levelDistiller.transform.Find("Rubber Connector").gameObject.SetActive(true);
            TutorialText.text = "Turn on the heat source and wait for the mixture to seperate into the graduated cylinder...";
        }
    }
}
