using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Square"))
        {
            gameController.IncreaseScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("DeathZone"))
        {
            gameController.DecreaseLive();
            Destroy(gameObject);

            if (gameController.IsGameOver)
            {
                gameController.EndGame();
            }
            Debug.Log("Failed");
        }
    }
}
