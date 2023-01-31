using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public Text lifeCounter; 
    public Text levelText; 
    public YellowFellowGame game;
    public Fellow fellow;
    // Start is called before the first frame update
    int levelNum;
    void Start()
    {
        levelNum = game.levelNo;
        highscoreText.text = "HIGHSCORE: " + game.HighScore.ToString();
        levelText.text = "Level: " + levelNum.ToString();
    }
    int score;
    int lives;
    // Update is called once per frame
    void Update()
    {
        score = fellow.pelletsEaten*100;
        lives = fellow.fellowLives +1;
        scoreText.text = "SCORE: " + score.ToString();
        lifeCounter.text = "Lives: " + lives.ToString();
    }
}
