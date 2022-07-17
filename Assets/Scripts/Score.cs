using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public Transform player;
    public int score;
    public int highScore;
    public int diff;
    public TextMeshProUGUI scoreOutput;
    public TextMeshProUGUI highscorescoreOutput;
    void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscorescoreOutput.text = PlayerPrefs.GetInt("highscore", 0).ToString();
            highScore = PlayerPrefs.GetInt("highscore", 0);
            global.highscore = highScore;
        }
		else
		{
            highscorescoreOutput.text = "000";

        }
    }

    
    void Update()
    {

        score = (int)player.position.y * diff + (int)((1000 - global.health) / 100f);
        if (score < global.bankedscore)
        {
            score = global.bankedscore;
        }
        global.score = score;

        scoreOutput.text = score.ToString();
        if(score > highScore)
        {
            highScore = global.bankedscore + score;
            global.highscore = highScore;
            highscorescoreOutput.text = highScore.ToString();
            PlayerPrefs.SetFloat("highscore", highScore);
        }
    }
}
