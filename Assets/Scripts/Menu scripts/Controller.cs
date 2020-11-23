using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField]
    GameObject player1Button;
    [SerializeField]
    GameObject player2Button;
    [SerializeField]
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
