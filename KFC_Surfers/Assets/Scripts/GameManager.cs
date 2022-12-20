using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scorevalue = 0;
    public GameObject logObstacleL;
    public GameObject logObstacleM;
    public GameObject logObstacleR;
    public GameObject logObstacleMLow;
    public bool gameHasEnded = false;
    public float restartDelay = 1f;
    public float gameSpeed = 1f;
    private IEnumerator coroutine;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r") && gameHasEnded == true)
            {
                Invoke("Restart", restartDelay);
            }
    }

    private int ObstacleType()
    {
        return Random.Range(0,3);
    }  

    public void ScoreIncrease()
    {
        scorevalue+=1;
        scoreText.text="Score : "+scorevalue.ToString("0");
        Debug.Log("Score increased");
    }

    private IEnumerator WaitAndSpawn(float waitTime)
    {
        while (!gameHasEnded)
        {
            ScoreIncrease();
            yield return new WaitForSeconds(waitTime);
            spawnObstacle();
        }
    }

    private void Start()
    {
        coroutine = WaitAndSpawn(1f);
        StartCoroutine(coroutine);
        scorevalue = 0;
    }
    private void spawnObstacle()
    {
        int obstacleType = ObstacleType();
        if(obstacleType == 0)
        {
            Instantiate(logObstacleL, transform);
        }
        else if(obstacleType == 1)
        {
            Instantiate(logObstacleM, transform);
        }
        else if(obstacleType == 2)
        {
            Instantiate(logObstacleR, transform);
        }
        else if(obstacleType == 3)
        {
            Instantiate(logObstacleMLow, transform);
        }
    }
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");// poprawić na napis na UI
            //użyć w updatcie z flagą
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
