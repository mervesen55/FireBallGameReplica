using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject Tank;
    public Vector3 setoff;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Tank.transform.position + setoff;
    }

    //public void RotateCamera()
    //{
    //    transform.Rotate(0, -10, 0);
        
    //}
}
