using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatSource : MonoBehaviour
{
    public bool isHolding = false;
    public Color[] colors = new Color[] {Color.white, Color.red};
    Transform ObjectDest;
    //Text UIText;
    Vector3 buttonShift = new Vector3(0f, 0f, 0.02f);
    bool isOn = false;

    void Start()
    {
        ObjectDest = GameObject.Find("ObjectDest").transform;
        //UIText = GameObject.Find("InteractionText").GetComponent<Text>();
    }

    void Update()
    {

    }

    /*
    void OnMouseOver()
    {
        UIText.text = "Click LMB to Turn Heat Source On/Off";
    }

    void OnMouseExit()
    {
        UIText.text = "";
    }
    */

    void OnMouseDown()
    {
        if (isOn == true)
        {
            this.transform.position -= buttonShift;
            GetComponent<Renderer>().material.color = colors[0];
            isOn = false;
        }
        else
        {
            this.transform.position += buttonShift;
            GetComponent<Renderer>().material.color = colors[1];
            isOn = true;
        }
    }

}
