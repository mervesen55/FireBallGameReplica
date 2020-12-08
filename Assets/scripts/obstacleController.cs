using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleController : MonoBehaviour
{

    ParticleSystem particle;

    //[SerializeField]
    //Transform RotationCenter;
    //float timeCounter = 0;
    //float speed;
    //float width;
    //float height;
    // Start is called before the first frame update
    void Start()
    {
        //speed = 1;
        //height = 15;
        //width = 15;
        particle = GameObject.Find("particle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        //timeCounter += Time.deltaTime * speed;
        //float x = RotationCenter.position.x + Mathf.Cos(timeCounter) * width;
        //float z = RotationCenter.position.z + Mathf.Sin(timeCounter) * height;
        //float y = 1;
        //transform.position = new Vector3(x,y,z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.transform.gameObject);
        particle.transform.position = collision.transform.position;
        particle.Play();
        Invoke("StopParticle", 3f);
        //var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        //sphere.AddComponent<Rigidbody>().velocity = new Vector3(0, 10, -10);
        //Destroy(sphere, 2f);

        GameManager.Instance.GameOver();
    }

    private void StopParticle()
    {
        particle.Stop();
    }
}
