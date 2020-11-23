using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Transform ball;
    int firstPlayerScore = 0;
    int secondPlayerScore = 0;
    [SerializeField]
    GameObject firstPlayer;
    [SerializeField]
    GameObject secondPlayer;

    private void Start()
    {
        if(PlayerInfo.IsSinglePlayer)
        {
            if(PlayerInfo.player == 1)
            {
                //Подключить ИИ для первого игрока
                Destroy(secondPlayer.GetComponent<PlayerController>(), 0);
                secondPlayer.AddComponent<AI>();
            }
            else
            {
                //Подключить ИИ для второго игрока
                Destroy(firstPlayer.GetComponent<PlayerController>(), 0);
                firstPlayer.AddComponent<AI>();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }

    //Ведение счета
    void Score(string sender)
    {
        if (sender == "Player 1 wall")
            secondPlayerScore++;
        else
            firstPlayerScore++;
        scoreText.text = $"Score {firstPlayerScore}:{secondPlayerScore}";
        ball.SendMessage("Score");
    }
}
