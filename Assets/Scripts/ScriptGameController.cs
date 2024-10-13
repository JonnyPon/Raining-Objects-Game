using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptGameController : MonoBehaviour
{
   public GameObject rain;
   public Vector3 spawnValues;
   public int rainCount;
   public float spawnWait;
   public float startWait;
   public float rainWait;

   private int score;
   public TextMeshProUGUI scoreText;

   public int lives;
   public TextMeshProUGUI livesText;

   void Start()
   {
        score = 0;
        UpdateScore();
        UpdateLives();

        StartCoroutine(SpawnRain());
   }

   void UpdateScore()
   {
        scoreText.text = "Score: " + score;
   }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void RemoveLive()
    {
        lives = lives - 1;
        UpdateLives();
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
