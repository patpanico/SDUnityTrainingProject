using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pourFluid : MonoBehaviour
{

    private GameObject go;
    public float minTilt = -10;
    public float maxTilt = 0;

    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z) && go.transform.rotation.z > minTilt) { go.transform.Rotate(0, 0, -1); }
        else if(Input.GetKey(KeyCode.X) && go.transform.rotation.z < maxTilt) { go.transform.Rotate(0, 0, 1); }
    }
}
