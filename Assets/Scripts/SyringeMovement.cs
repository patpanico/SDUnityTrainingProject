using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeMovement : MonoBehaviour
{
    public float speed;
    public GameObject syringe;
    PickUp syringe_script;
    public GameObject tube;
    bool tubeCollision = true;

    void Start()
    {
        speed = 5f;
        syringe_script = syringe.GetComponent<PickUp>();
    }

    void Update()
    {
        if (syringe_script.isHolding)
        {
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(0, 0, vertical);
        }
    }

  /*
    private void OnTriggerEnter(Collider other)
    {
        tubeCollision = true;
    }
  */
}
