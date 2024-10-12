using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameController : MonoBehaviour
{
   public GameObject rain;
   public Vector3 spawnValues;
   public int rainCount;
   public float spawnWait;
   public float startWait;
   public float rainWait;

   void Start()
   {
        StartCoroutine(SpawnRain());
   }

   IEnumerator SpawnRain()
   {
        yield return new WaitForSeconds(startWait);

        while(true)
        {
            for(int i = 0; i < rainCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 
                                            spawnValues.y,
                                            spawnValues.z);

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(rain, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(rainWait);
        }

        
   }
}
