using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField]
    //Кнопка "Player 1"
    GameObject player1Button;
    [SerializeField]
    //Кнопка "Player 2"
    GameObject player2Button;
    [SerializeField]
    //Canvas в котором расположены кнопки
    Transform canvas;
    void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    void PlaySolo()
    {
        Destroy(GameObject.Find("Player vs computer"), 0);
        Destroy(GameObject.Find("Player vs player"), 0);
        Instantiate(player1Button, canvas);
        Instantiate(player2Button, canvas);
        PlayerInfo.IsSinglePlayer = true;
    }

    void Exit()
    {
        Application.Quit();
    }
}
