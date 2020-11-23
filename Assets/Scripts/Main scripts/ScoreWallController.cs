using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWallController : MonoBehaviour
{
    [SerializeField]
    GameObject scoreController;
    
    //Засчитывает попадание
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            scoreController.SendMessage("Score", gameObject.name);
    }
}
