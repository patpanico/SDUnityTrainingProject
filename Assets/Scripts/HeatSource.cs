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

    void Start()
    {
        levelScript = levelScriptObj.GetComponent<ChemLabTutorial>();
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
        if (isOn)
            TurnOff();
        else if (!isOn && levelScript.IsHeatReady())
            TurnOn();
    }


}
