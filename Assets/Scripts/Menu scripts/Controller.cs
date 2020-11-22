using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    Button playButton;
    [SerializeField]
    Button exitButton;
    void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    void PlaySolo()
    {
        PlayerInfo.IsSinglePlayer = true;
        SceneManager.LoadScene("MainScene");
    }
    void Exit()
    {
        Application.Quit();
    }
}
