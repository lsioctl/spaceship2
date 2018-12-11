using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float spawnInterval;
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    public GameObject boss1;
    public int bos1SpawnScore;
    private bool boss1Created;


    // Use this for initialization
    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        boss1Created = false;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                // this is deprecated
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    // coroutine to avoid wait between instantiate pausing the all game
    // coroutine can't return void
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (score < bos1SpawnScore)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    // the object is spawn with no rotation at all
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            yield return new WaitForSeconds(spawnInterval);
            }
            // Handle the boss
            else
            {
                if (boss1Created == false)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    // the object is spawn with no rotation at all
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(boss1, spawnPosition, spawnRotation);
                    boss1Created = true;
                    yield return 0;
                } else
                {
                    yield return 0;
                }
            }
            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }

	
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
	
}
