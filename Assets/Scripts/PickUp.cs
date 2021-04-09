using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public bool isHolding = false;
    Transform ObjectDest;
    Text UIText;
    float maxDistance = 2.5f;

    void Start()
    {
        ObjectDest = GameObject.Find("ObjectDest").transform;
        UIText = GameObject.Find("InteractionText").GetComponent<Text>();
    }

    void Update()
    {
        if (isHolding)
            WhileHolding();
    }

    void WhileHolding()
    {
        if (GetDistance() > maxDistance)
            ReleaseObject();
        else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    void PickUpObject()
    {
        isHolding = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = ObjectDest.position;
        this.transform.parent = GameObject.Find("ObjectDest").transform;
    }

    void HoldingObject()
    {
        this.transform.position = ObjectDest.position;
        this.transform.parent = GameObject.Find("ObjectDest").transform;
    }

    void ReleaseObject()
    {
        isHolding = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
    }

    void OnMouseOver()
    {
        if (!isHolding && GetDistance() <= maxDistance)
            UIText.text = "Hold LMB to Pick Up";
    }

    void OnMouseExit()
    {
        if (!isHolding && GetDistance() <= maxDistance)
            UIText.text = "";
    }

    void OnMouseDown()
    {
        if (GetDistance() <= maxDistance) {
            UIText.text = "";
            PickUpObject();
        }
    }

    void OnMouseUp()
    {
        if (isHolding == true)
            ReleaseObject();
    }

    float GetDistance()
    {
        return Vector3.Distance(this.transform.position, ObjectDest.transform.position);
    }
}
