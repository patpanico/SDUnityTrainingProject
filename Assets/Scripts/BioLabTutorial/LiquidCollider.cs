using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidCollider : MonoBehaviour
{
    public GameObject levelScript;

    void OnTriggerEnter(Collider col)
    {
        levelScript.GetComponent<BioLabTutorial>().CheckObject(col.gameObject);
    }
}
