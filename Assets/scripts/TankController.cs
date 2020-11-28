using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            transform.position += transform.forward * Time.deltaTime * -speed;
        }
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
