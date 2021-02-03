using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAndRotate : MonoBehaviour
{
    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        // assign 'gameObject' object to a new variable 'go'
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 'A' key rotates gameobject to the left
        // 'D' key rotates gameobject to the right
        // 'up arrow' key moves gameobject forward
        // 'down arrow' key moves gameobject backward
        // 'left arrow' key moves gameobject to the left
        // 'right arrow' key moves gameobject to the right
        if(Input.GetKey(KeyCode.A)) { go.transform.Rotate(0, -1f, 0, Space.World); }
        else if(Input.GetKey(KeyCode.D)) { go.transform.Rotate(0, 1f, 0, Space.World); }
        else if (Input.GetKey(KeyCode.UpArrow)) { go.transform.position = new Vector3(go.transform.position.x + 0.1f, go.transform.position.y, go.transform.position.z); }
        else if (Input.GetKey(KeyCode.DownArrow)) { go.transform.position = new Vector3(go.transform.position.x - 0.1f, go.transform.position.y, go.transform.position.z); }
        else if (Input.GetKey(KeyCode.LeftArrow)) { go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z + 0.1f); }
        else if (Input.GetKey(KeyCode.RightArrow)) { go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z - 0.1f); }
    }
}
