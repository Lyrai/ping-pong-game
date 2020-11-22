using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWallController : MonoBehaviour
{
    [SerializeField]
    GameObject scoreController;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            Score();
    }

    void Score()
    {
        scoreController.SendMessage("Score", Random.Range(-25, 25) * Mathf.Deg2Rad);
    }
}
