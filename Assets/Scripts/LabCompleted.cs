﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabCompleted : MonoBehaviour
{
    public GameObject CrosshairObj;
    public static bool isCompleted;

    public void Completed()
    {
        isCompleted = true;
        this.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CrosshairObj.SetActive(false);
        Time.timeScale = 0f;
    }
}
