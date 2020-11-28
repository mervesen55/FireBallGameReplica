using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.DestroyCapsules();
        Destroy(collision.transform.gameObject);
        GameManager.Instance.BallHasDestroyed = true;
    }
}
