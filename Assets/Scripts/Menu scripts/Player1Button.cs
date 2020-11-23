using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Button : MonoBehaviour
{
    void SelectPlayer1()
    {
        PlayerInfo.player = 1;
        SceneManager.LoadScene("MainScene");
    }
}
