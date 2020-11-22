using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Transform ball;
    int firstPlayerScore = 0;
    int secondPlayerScore = 0;
    void Score(string sender)
    {
        if (sender == "Player 1 wall")
            secondPlayerScore++;
        else
            firstPlayerScore++;
        scoreText.text = $"Score {firstPlayerScore}:{secondPlayerScore}";
        ball.position = Vector2.zero;
        ball.SendMessage("SetDirection");
    }
}
