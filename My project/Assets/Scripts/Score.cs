using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {// TODO Zmienić score żeby zaczynał się od 0 nie od -18
        scoreText.SetText(player.position.z.ToString("0"));
        //scoreText.Text= player.position.z.ToString("0"); ;
    }
}
