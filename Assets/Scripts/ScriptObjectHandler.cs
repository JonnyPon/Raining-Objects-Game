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
}
