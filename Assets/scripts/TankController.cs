using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public static TankController instance;
    public bool TankIsMoving = true;
    public bool stage1HasStarted = false;
    public bool stage2HasStarted = false;
    public MainCameraController mainCamera;
    private float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stage1Trigger" && !stage1HasStarted)
        {
            StopTank(); // to fire
            GameManager.Instance.spawnObstacle(1);
            stage1HasStarted = true;
            GameManager.Instance.SetSteps(1);
            
        }
        
        if (other.tag == "Stage2Trigger" && !stage2HasStarted)
        {
            StopTank(); // to fire
            stage2HasStarted = true;
            GameManager.Instance.SetSteps(2);
            GameManager.Instance.spawnObstacle(2);
        }

        if (other.tag == "intersection")
        {
            transform.Rotate(0, -10, 0);
           //mainCamera.RotateCamera();
        }
        if (other.tag == "startPoint" && GameManager.Instance.Level > 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }

    public void StopTank()
    {
        speed = 0;
        TankIsMoving = false;
    }
    public void RestartTank()
    {
        if (!stage2HasStarted)
        {
            
            speed = 10;
            TankIsMoving = true;
        }
    }
    public void setTankPosition()
    {
        transform.position = new Vector3(6.6f, 1, 19.1f);
    }


}
