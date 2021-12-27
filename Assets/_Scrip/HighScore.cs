using System;
using System.Collections;
using System.Collections.Generic;
using _Scrip;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highscore",0).ToString();
    }

    public void UpdateHighscore()
    {

        score.text = GameController.instance._score.ToString();
        if (GameController.instance._score > PlayerPrefs.GetInt("highcore",0))
        {
            PlayerPrefs.SetInt("highscore",GameController.instance._score);
            highScore.text = GameController.instance._score.ToString();
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
