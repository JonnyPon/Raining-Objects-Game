using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptObjectHandler : MonoBehaviour
{
    public float tumbleSpeed;
    public GameObject deathExplosion;
    public GameObject caughtExplosion;

    public int scoreValue;
    private ScriptGameController gameControllerScript;

    private Rigidbody rb;

   void Awake()
   {
        rb = GetComponent<Rigidbody>();

        GameObject gameController = GameObject.FindWithTag("GameController");

        if(gameController != null)
        {
            gameControllerScript = gameController.GetComponent<ScriptGameController>();
        }
        else{
            Debug.Log("Cannot find 'GameController' script");
        }
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
            Instantiate(caughtExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameControllerScript.AddScore(scoreValue);
            return;
        }
        else if(other.CompareTag("DeathZone"))
        {
            Instantiate(deathExplosion, transform.position, transform.rotation);
            gameControllerScript.RemoveLive();
            return;
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
