using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPopup : MonoBehaviour
{
    public GameObject CrosshairObj;
    Text PopupText;

    void Start()
    {
        PopupText = this.transform.Find("PopupText").GetComponent<Text>();
    }

    public void OpenPopup(string text)
    {
        PopupText.text = text;
        this.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CrosshairObj.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ClosePopup()
    {
        this.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CrosshairObj.SetActive(true);
        Time.timeScale = 1f;
    }
}
