using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ballObject;
    public float timeToCreateBall = 2;
    private float m_TimeToCreatBall;
    private int score = 0;
    public int countLive = 3;
    public bool IsGameOver => countLive == 0;
    private UIController uIController;
    // Start is called before the first frame update
    void Start()
    {
        CreateBallRandom();
        uIController = FindObjectOfType<UIController>();
        uIController.CreateHeartImage(countLive);
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeToCreatBall += Time.deltaTime;
        if (m_TimeToCreatBall >= timeToCreateBall && !IsGameOver)
        {
            CreateBallRandom();
            m_TimeToCreatBall = 0;
        }
    }

    void CreateBallRandom()
    {
        Vector2 vector2 = new Vector2(Random.Range(-9, 9), 6);
        Instantiate(ballObject, vector2, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void DecreaseLive()
    {
        countLive--;
        uIController.DestroyHeartImageById(countLive);
        Debug.Log("Live: " + countLive);
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        //Destroy(gameObject);
        // Application.Quit();
    }

    public int GetScore()
    {
        return score;  // Return the score value. This method is public for other scripts to access the score.  // Example: var scoreText = gameController.GetScore().ToString();  // Update the score text in the UI.  // Note: This method should not be called from the Update() method because it will be called every frame.  // If you want to update the score text only when the score changes, consider using Unity's UnityEvent system or Unity's built-in UI system.  // This method does not return the current score value; it returns the score value at the time the method was called.  // If you want to access the current score value, consider using a public variable in the GameController script to store the score and access it from other scripts.  // Example: var scoreText = gameController.score.ToString();  // Update the score text in the UI.  // Note: This method should not be called from the Update()
    }

    public void Replay()
    {
        countLive = 3;
        score = 0;
        uIController.SetPanelActive(false);
        uIController.CreateHeartImage(countLive);
        Debug.Log("Replay");
    }
}
