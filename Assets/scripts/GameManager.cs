using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float CapsuleYPos = 0.80f;
    private int i = 1;
    private float speed = 10;
    public bool BallHasDestroyed = false;
    public static GameManager Instance;
    public GameObject Tank;
    public GameObject Firstcapsule;
    public List<GameObject> points = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        BallHasDestroyed = true; //To be able to spawn one ball at the beginnig
        for (int i = 1; i < 15; i++)
        {
            
            spawnCapsules();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            spawnBomb();
            
            
        }
    }

    void spawnCapsules()
    {
        Vector3 pos = new Vector3(-0.1f, CapsuleYPos, 58.8f);
        CapsuleYPos += 0.7f;
        GameObject a = Instantiate(Firstcapsule, pos, Quaternion.identity);
        points.Add(a);
    }
    void UpdateCapsulesPositions()
    {
        for (int i = 13; i > 0; i--)
        {
            points[i].transform.position = points[i].transform.position + new Vector3(0, -0.7f, 0f);
        }
    }

    void spawnBomb()
    {
        if (BallHasDestroyed)
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.localScale = new Vector3();
            sphere.transform.position = new Vector3(Tank.transform.position.x, 1.5f, Tank.transform.position.z);
            // sphere.transform.position += transform.forward * Time.deltaTime * speed;
            sphere.AddComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            Destroy(sphere, 5f);
            BallHasDestroyed = false;
        }
      
    }

    public void DestroyCapsules()
    {
        if (BallHasDestroyed)
        {
            Destroy(points[0]);
            points[0] = points[i];
            i += 1;
            UpdateCapsulesPositions();
        }
        
    }

}
