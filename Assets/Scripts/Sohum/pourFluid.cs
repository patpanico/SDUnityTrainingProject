using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pourFluid : MonoBehaviour
{

    private GameObject go;
    public float minTiltRotate = -4;
    public float maxTiltRotate = 4;

    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Z) && go.transform.rotation.x > minTiltRotate) { go.transform.Rotate(-1f, 0, 0); }
        else if(Input.GetKey(KeyCode.X) && go.transform.rotation.x < maxTiltRotate) { go.transform.Rotate(1f, 0, 0); }
    }

}
