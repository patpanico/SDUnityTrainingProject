using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatSource : MonoBehaviour
{
    public GameObject levelScriptObj;
    ChemLabTutorial levelScript;
    Vector3 buttonShift = new Vector3(0f, 0f, 0.01f);
    bool isOn;
    Transform ObjectDest;
    Text UIText;
    float maxDistance = 2.5f;

    void Start()
    {
        levelScript = levelScriptObj.GetComponent<ChemLabTutorial>();
        ObjectDest = GameObject.Find("ObjectDest").transform;
        UIText = GameObject.Find("InteractionText").GetComponent<Text>();
    }

    void TurnOn()
    {
        isOn = true;
        this.transform.position += buttonShift;
        GetComponent<Renderer>().material.color = Color.red;
        levelScript.TurnOnHeat();
    }

    void TurnOff()
    {
        isOn = false;
        this.transform.position -= buttonShift;
        GetComponent<Renderer>().material.color = Color.black;
        levelScript.TurnOffHeat();
    }

    void OnMouseDown()
    {
        if (GetDistance() <= maxDistance) {
            if (isOn && levelScript.IsHeatReadyToOff()) {
                UIText.text = "";
                TurnOff();
            }
            else if (!isOn && levelScript.IsHeatReady()) {
                UIText.text = "";
                TurnOn();
            }
        }
    }

    void OnMouseOver()
    {
        if (GetDistance() <= maxDistance) {
            if (isOn && levelScript.IsHeatReadyToOff())
                UIText.text = "Click LMB to Turn Off Heat Source";
            else if (!isOn && levelScript.IsHeatReady())
                UIText.text = "Click LMB to Turn On Heat Source";
        }
    }

    void OnMouseExit()
    {
        if (((!isOn && levelScript.IsHeatReady()) || (isOn && levelScript.IsHeatReadyToOff())) && GetDistance() <= maxDistance)
            UIText.text = "";
    }

    float GetDistance()
    {
        return Vector3.Distance(this.transform.position, ObjectDest.transform.position);
    }
}
