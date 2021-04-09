using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemLabTutorial : MonoBehaviour
{
    Text TutorialText;

    void Start()
    {
        TutorialText = GameObject.Find("TutorialText").GetComponent<Text>();
    }

    void Update()
    {
        
    }


}
