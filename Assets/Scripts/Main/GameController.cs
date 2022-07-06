using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    private int score = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE:" + score;
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    public void UnveilGameOverText()
    {
        gameOverText.SetActive(true);
    }
}
