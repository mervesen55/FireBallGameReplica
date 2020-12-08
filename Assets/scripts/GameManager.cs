using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int index = 0;// for DestroyCapsules method
    private float speed = 20;
    private float CapsuleYPos = 0.80f;
    private float CapsuleXPos = -0.1f;
    private float CapsuleZPos = 68.8f;
    private int i = 0;
    public static GameManager Instance;
    public GameObject Tank;
    public GameObject Firstcapsule;
    public GameObject GameOverCanvas;
    // public GameObject GameCompletedCanvas;
    public int stage = 1;
    public int Level = 1;
    public int NumberOfCapsules = 54;
    public int[] NewNumberOfCapsules;
    public List<GameObject> capsules = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Level = 1;
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
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(Tank.transform.position.x, 1.5f, Tank.transform.position.z);
        sphere.AddComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        Destroy(sphere, 2f);//if bomb miss the capsules, we need to destroy it anyway
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
            SetLevels();

    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        GameOverCanvas.SetActive(true);


    }




    public void SetSteps(int StepNumber)
    {
        stage += 1;
        if (StepNumber == 1)
        {
            CapsuleZPos = 68.8f;

        }
        if (StepNumber == 2)
        {
            CapsuleZPos = 198.8f;
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
            //GameCompletedCanvas.SetActive(true);
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

}
