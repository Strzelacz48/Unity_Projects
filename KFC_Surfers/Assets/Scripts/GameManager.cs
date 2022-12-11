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
    public GameObject logObstacleP;
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

    /*private IEnumerator WaitAndSpawn(float waitTime)
    {
    }*/

    private void Start()
    {
        /*coroutine = WaitAndSpawn(1.5f);
        StartCoroutine(coroutine);*/
        scorevalue = 0;
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
