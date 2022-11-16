using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject swordGate;
    public bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public int scorevalue = 0;
    private IEnumerator coroutine;
    
    private int hight()
    {
        int wynik = -Random.Range(0,16);
        return wynik;
    }
    private void Start() {
        //rnd = new Random();
        coroutine = WaitAndSpawn(1.5f);
        StartCoroutine(coroutine);
        scorevalue = 0;
    }

    public void ScoreIncrease()
    {
        scorevalue+=1;
        scoreText.text="Score : "+scorevalue.ToString("0");
        Debug.Log("Score increased");
    }

    private IEnumerator WaitAndSpawn(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            float pom = hight();
            print("WaitAndSpawn " + pom);
            GameObject obj = Instantiate(swordGate,transform); 
            obj.transform.position = new Vector3(75,pom,0);
            //GateMovment nSwordGate = obj.GetComponent<GateMovment>();
            //nSwordGate.gameManager = this;
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
