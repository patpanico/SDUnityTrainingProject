﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistillerCollider : MonoBehaviour
{
    public GameObject levelScript;

    void OnTriggerEnter(Collider col)
    {
        levelScript.GetComponent<ChemLabTutorial>().CheckObject(col.gameObject);
    }
}
