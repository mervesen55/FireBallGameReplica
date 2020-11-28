using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour
{
    [SerializeField]
    Transform RotationCenter;
    float timeCounter = 0;
    float speed;
    float width;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        height = 20;
        width = 20;
        
    }

    // Update is called once per frame
    void Update()
    {

        timeCounter += Time.deltaTime * speed;
        Debug.Log(timeCounter);
        float x = RotationCenter.position.x + Mathf.Cos(timeCounter) * width;
        float z = RotationCenter.position.z + Mathf.Sin(timeCounter) * height;
        float y = 1;
        transform.position = new Vector3(x,y,z);
    }
}
