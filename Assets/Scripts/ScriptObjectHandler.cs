using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptObjectHandler : MonoBehaviour
{
    public float tumbleSpeed;
    private Rigidbody rb;

   void Awake()
   {
        rb = GetComponent<Rigidbody>();
   }

    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumbleSpeed; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary"))
        {
            return;
        }
        else if(other.CompareTag("Player")){
            Destroy(gameObject);
            return;
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
