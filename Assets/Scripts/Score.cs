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
        }
		else
		{
            highscorescoreOutput.text = "000";

        }
    }

    
    void Update()
    {

        score = (int) player.position.y * diff;
        scoreOutput.text = score.ToString();
        if(score > highScore)
		{
            highScore = score;
            highscorescoreOutput.text = highScore.ToString();
            PlayerPrefs.SetFloat("highscore", highScore);
        }
    }
}
