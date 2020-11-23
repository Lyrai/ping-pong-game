using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Button : MonoBehaviour
{
    void SelectPlayer2()
    {
        PlayerInfo.player = 2;
        SceneManager.LoadScene("MainScene");
    }
}
