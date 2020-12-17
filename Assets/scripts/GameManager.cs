using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int index = 0;// for DestroyCapsules method
    private float speed = 20;
    private float CapsuleYPos = 0.80f;
    private float CapsuleXPos = 6.81f;
    private float CapsuleZPos = 40.98f;
    private int i = 0;
    private int bombXspeed = 0;
    public static GameManager Instance;
    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject RotationCenter1;
    public GameObject RotationCenter2;
    public GameObject bomb;
    public GameObject Tank;
    public GameObject Firstcapsule;
    public GameObject GameOverCanvas;
    public int stage = 1;
    public int Level = 1;
    public int NumberOfCapsules = 54;
    public int[] NewNumberOfCapsules;
    public List<GameObject> capsules = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !TankController.instance.TankIsMoving)
        {
            
            spawnBomb();
        }

    }


    void spawnCapsules()
    {
        Vector3 pos = new Vector3(CapsuleXPos, CapsuleYPos, CapsuleZPos);
        GameObject capsule = Instantiate(Firstcapsule, pos, Quaternion.identity);
        CapsuleYPos += 0.7f;
        capsules.Add(capsule);
        if (i % 2 == 0)
            capsules[i].GetComponent<Renderer>().material.color = Color.red;
        if (i % 2 == 1)
            capsules[i].GetComponent<Renderer>().material.color = Color.yellow;
        if (i < NumberOfCapsules)
            i++;
    }
    void UpdateCapsulesPositions()
    {
        for (int i = NumberOfCapsules - 1; i > 0; i--)
        {
            if (capsules[i] != null)
                capsules[i].transform.position = capsules[i].transform.position - new Vector3(0, 0.7f, 0f);

        }
    }

    void spawnBomb()
    {
        //Vector3 pos = new Vector3(Tank.transform.position.x, 1f, Tank.transform.position.z);
        //GameObject Bomb = Instantiate(bomb, pos, Quaternion.identity);
        var Bomb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Bomb.transform.position = new Vector3(Tank.transform.position.x, 1f, Tank.transform.position.z);
        Bomb.transform.position += transform.forward * Time.deltaTime * speed;
        Bomb.AddComponent<Rigidbody>().velocity = new Vector3(bombXspeed, 0, speed);
        Bomb.GetComponent<Rigidbody>().useGravity = false;
        Destroy(Bomb, 2f);//if bomb miss the capsules, we need to destroy it anyway
    }

    public void DestroyCapsules()
    {

        if (index < NumberOfCapsules)
        {

            if (capsules[index] != null)
                Destroy(capsules[index]);
            index += 1;
            UpdateCapsulesPositions();

        }
        if (index == NumberOfCapsules)
        {
            SetLevels();
            TankController.instance.RestartTank();
            DestroyObstacle();
            
        }
            

    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        GameOverCanvas.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void SetSteps(int StepNumber)
    {
        stage += 1;
        if (StepNumber == 1)
        {
            CapsuleZPos = 40.98f;
            CapsuleXPos = 6.81f;
            bombXspeed = 0;
        }
        if (StepNumber == 2)
        {
            CapsuleZPos = 75.95f;
            CapsuleXPos = -8f;
            bombXspeed = -8;
            ResetValues();

        }
        for (int i = 0; i < NumberOfCapsules; i++)
        {
            spawnCapsules();
        }
    }

    private void SetLevels()
    {

        if (TankController.instance.stage2HasStarted)
        {
            Level += 1;
            Debug.Log("LEVEL WON");
            ResetValues();
            TankController.instance.setTankPosition();
            TankController.instance.stage1HasStarted = false;
            TankController.instance.stage2HasStarted = false;

        }
    }

    private void ResetValues()
    {
        CapsuleYPos = 0.8f;
        NumberOfCapsules = NewNumberOfCapsules[stage];
        index = 0;
        i = 0;
        capsules.Clear();

    }


    public void spawnObstacle(int stage)
    {
        if (stage == 1)
        {
            Debug.Log("hiyır");
            Obstacle1.SetActive(true);
        }


        if (stage == 2)
            Obstacle2.SetActive(true);
    }


    public void DestroyObstacle()
    {
        Obstacle1.SetActive(false);
        Obstacle2.SetActive(false);
    }
}
