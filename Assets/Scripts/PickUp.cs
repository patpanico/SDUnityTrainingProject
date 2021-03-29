using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    bool isHolding = false;
    public Transform ObjectDest;

    void Update()
    {
        if (isHolding)
            WhileHolding();
    }

    void WhileHolding()
    {
        if (Vector3.Distance(this.transform.position, ObjectDest.transform.position) > 2.5f)
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

    void ReleaseObject()
    {
        isHolding = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, ObjectDest.transform.position) <= 2.5f)
            PickUpObject();
    }

    void OnMouseUp()
    {
        ReleaseObject();
    }
}
