using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    
    private bool isGameOver;
    private bool isRestart;
   void Start()
   {
        isGameOver = false;
        isRestart = false;
        gameOverText.text = "";
        restartText.text = "";

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
        if(!isGameOver)
        {
            score += newScoreValue;
            UpdateScore();
        }
        
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void RemoveLive()
    {
        if(!isGameOver)
        {
            lives = lives - 1;
            UpdateLives();
        }
        
    

        if(lives <= 0)
        {
            GameOver();
        }
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

             if(isGameOver)
            {
                restartText.text = "Press 'R' to Restart or 'ESC' to Exit";
                isRestart = true;
                break;
            }
        } 


   }

   void Update()
   {
        if(isRestart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
   }

   public void GameOver()
   {
        gameOverText.text = "Game Over";
        isGameOver = true;
   }
}
