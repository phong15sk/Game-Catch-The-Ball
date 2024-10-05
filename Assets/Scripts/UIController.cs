using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject panel;
    public GameObject heartImageObject;
    private GameController gameController;
    private float heartImagePositionX = -8F;
    private float heartImagePositionY = 4.29F;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        scoreText.text = "Score:  " + gameController.GetScore();

        if (gameController.IsGameOver)
        {
            SetPanelActive(true);
        }
    }

    public void SetPanelActive(bool active)
    {
        panel.gameObject.SetActive(active);
    }

    public void CreateHeartImage(int number)
    {
        var renderer = heartImageObject.GetComponent<Renderer>();
        float width = renderer.bounds.size.x;
        for (int i = 0; i < number; i++)
        {
            var vector2 = new Vector2(heartImagePositionX + width * i, heartImagePositionY);
            GameObject newHeart = Instantiate(heartImageObject, vector2, Quaternion.identity);
            newHeart.GetComponent<Heart>().heartID = i;
        }
    }

    public void DestroyHeartImageById(int id)
    {
        Heart[] hearts = FindObjectsOfType<Heart>();

        foreach (Heart heart in hearts)
        {
            if (heart.heartID == id)
            {
                Destroy(heart.gameObject);
                break;
            }
        }
    }
}
