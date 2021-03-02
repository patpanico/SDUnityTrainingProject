using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndRotateObject : MonoBehaviour
{
    // GameObject to which this is attached
    private GameObject go;

    private Vector3 startPosition;

    // Variables for dragging objects
    private Vector3 mOffset;
    private float mZCoord;

    // rotate with keys "E" and "Q"
    // rotateOnKeyPress - rotate with keys only if true
    public bool rotateOnKeyPress = true;

    public bool resetPositionOnMouseUp = true;
    public bool resetRotationOnMouseUp = true;

    void Start()
    {
        go = gameObject;
        startPosition = go.transform.position;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(go.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = go.transform.position - GetMouseAsWorldPoint();
        
    }

    void OnMouseUp(){
        if(resetPositionOnMouseUp){ go.transform.position = startPosition; }
        if(resetRotationOnMouseUp){ go.transform.rotation = Quaternion.Euler(0, 0, 0); }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        go.transform.position = GetMouseAsWorldPoint() + mOffset;

        if(rotateOnKeyPress){
            if(Input.GetKey(KeyCode.Q)) { go.transform.Rotate(-1f, 0, 0); }
            else if(Input.GetKey(KeyCode.E)) { go.transform.Rotate(1f, 0, 0); }
        }
    }
}
