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
    private float timepom;
    private IEnumerator coroutine;
    public GameOverScreen gameOverScreen;
    // Update is called once per frame
    void Update()
    {
        if(!gameHasEnded)
        {
            if(timepom > 1)
            {
                timepom = 0;
                ScoreIncrease();
            }
            timepom+= 1 * Time.deltaTime;
        }

        if(Input.GetKeyDown("r") && gameHasEnded == true)
            {
                Invoke("Restart", restartDelay);
            }
    } 

    private void ScoreIncrease()
    {
            scorevalue+=1;
            scoreText.text="Score : "+scorevalue.ToString("0");
            Debug.Log("Score increased");
    }

    private int ObstacleType()
    {
        return Random.Range(0,4);
    } 

    private IEnumerator WaitAndSpawn()
    {
        float waitTime = 1f;
        while (!gameHasEnded)
        {
            //ScoreIncrease();
            yield return new WaitForSeconds(waitTime);
            int obstacleType = ObstacleType();
            print("WaitAndSpawn " + obstacleType);
            if(obstacleType == 0)
            {
                GameObject obj = Instantiate(logObstacleL, transform);
            }
            else if(obstacleType == 1)
            {
                GameObject obj = Instantiate(logObstacleM, transform);
            }
            else if(obstacleType == 2)
            {
                GameObject obj = Instantiate(logObstacleR, transform);
            }
            else if(obstacleType == 3)
            {
                GameObject obj = Instantiate(logObstacleMLow, transform);
            }
              
            //obj.transform.position = new Vector3(75,pom,0);
        }
    }

    private void Start()
    {
        StartCoroutine(WaitAndSpawn());
        scorevalue = 0;
    }

    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverScreen.Setup();
            Debug.Log("GAME OVER");
            //użyć w updatcie z flagą
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
