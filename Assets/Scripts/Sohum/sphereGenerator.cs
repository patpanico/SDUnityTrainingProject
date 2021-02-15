using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereGenerator : MonoBehaviour
{
    public float waitTime = 2;
    public Transform prefabType;
    public int count;


    // Start is called before the first frame update
    void Start()
    {
        // if(count > 0)
        // {
        //     for(int i = 0; i<count; i++)
        //     {
        //         Instantiate(prefabType, new Vector3(0, 6, 0), Quaternion.identity);
        //         StartCoroutine(coroutineWait());
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator coroutineWait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
