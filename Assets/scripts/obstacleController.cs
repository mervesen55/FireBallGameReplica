using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class obstacleController : MonoBehaviour
{
   public static obstacleController instance;
  
  // private Vector3 obstaclePos;
   private ParticleSystem particle;
    void Start()
    {
        instance = this;
        particle = GameObject.Find("Particle").GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.transform.gameObject);
        particle.transform.position = collision.transform.position;
        particle.Play();
        Invoke("StopParticle", 2f);
        GameManager.Instance.GameOver();
    }

    private void StopParticle()
    {
        particle.Stop();
    }


    
   
}
