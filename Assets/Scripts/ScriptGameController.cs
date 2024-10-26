using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScriptGameController : MonoBehaviour
{
    public GameObject[] fallingObjects;
    public Vector3 spawnValues;
    public int objectCount;
    public float spawnWait; 
    public float minSpawnWait = 0.5f; 
    public float objectSpawnWaitIncrement = 0.01f;
    public float playerSpeedIncrement = 0.001f;
    public float startWait;
    public float waveWait;
    
    private int score;
    public TextMeshProUGUI scoreText;

    public int lives;
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;

    private bool isGameOver;
    private bool isRestart;

    public ScriptPlayerController playerController;

    void Start()
    {
        isGameOver = false;
        isRestart = false;
        gameOverText.text = "";
        restartText.text = "";

        score = 0;
        UpdateScore();
        UpdateLives();

        StartCoroutine(SpawnObjects());
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        if (!isGameOver)
        {
            score += newScoreValue;
            UpdateScore();

            // Adjust the spawn wait time based on the score, and cap it at a minimum value
            spawnWait = Mathf.Max(minSpawnWait, spawnWait - score * objectSpawnWaitIncrement);

            // Gradually increase player movement speed based on the score
            playerController.IncreasePlayerSpeed(score * playerSpeedIncrement);
        }
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void RemoveLive()
    {
        if (!isGameOver)
        {
            lives = lives - 1;
            UpdateLives();
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < objectCount; i++)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x),
                    spawnValues.y,
                    spawnValues.z
                );

                Quaternion spawnRotation = Quaternion.identity;

                GameObject fallingObject = fallingObjects[Random.Range(0, fallingObjects.Length)];

                Instantiate(fallingObject, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (isGameOver)
            {
                restartText.text = "Press 'R' to Restart or 'ESC' to Exit";
                isRestart = true;
                break;
            }
        }
    }

    void Update()
    {
        if (isRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
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
