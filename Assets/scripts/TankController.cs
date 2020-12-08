using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public static TankController instance;
    public bool stage1HasStarted = false;
    public bool stage2HasStarted = false;
    private float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
            transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Stage1Trigger" && !stage1HasStarted)
        {
            stage1HasStarted = true;
            GameManager.Instance.SetSteps(1);

        }

        if (other.tag == "Stage2Trigger" && !stage2HasStarted)
        {
            stage2HasStarted = true;
            GameManager.Instance.SetSteps(2);

        }
    }

    //public void setTankSpeed()
    //{
    //    if ( !stage2HasStarted)
    //    {
    //        speed = 10;

    //    }
    //}

    public void setTankPosition()
    {
        transform.position = new Vector3(0, 1, 22.5f);
    }
}
