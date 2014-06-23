using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public static int comboCounter;
    public static int coinCounter;
    public static int moneyCounter;

    [HideInInspector]
    public int scoreCounter;

    //SCORE UTILITY
    int combinationsScoreCheck;
    int coinScoreCheck;
    int moneyScoreCheck;
    int scoreCheck;
    int scoreInfiniteCheck;

    int maxScore = 4000;
    int threeStarsAnchor = 3600;
    int twoStarsAnchor = 2600;
    int oneStarAnchor = 1600;

    public static bool threeStars;
    public static bool twoStars;
    public static bool oneStar;

	// Use this for initialization
	void Start () {
        //Gets the scores
        combinationsScoreCheck = PlayerPrefs.GetInt("HighComb");
        coinScoreCheck = PlayerPrefs.GetInt("HighCoins");
        moneyScoreCheck = PlayerPrefs.GetInt("HighMoney");
        scoreCheck = PlayerPrefs.GetInt("HighScore");
        scoreInfiniteCheck = PlayerPrefs.GetInt("HighScoreInfinite");

        threeStars = false;
        twoStars = false;
        oneStar = false;

        comboCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetScore()
    {
        if (comboCounter > combinationsScoreCheck)
        {
            PlayerPrefs.SetInt("HighComb", comboCounter);
        }
        if (coinCounter > coinScoreCheck)
        {
            PlayerPrefs.SetInt("HighCoins", coinCounter);
        }
        if (moneyCounter > moneyScoreCheck)
        {
            PlayerPrefs.SetInt("HighMoney", moneyCounter);
        }
                
        if (Game_Manager.levelIsInfinite == true)
        {
            if (scoreCounter > scoreInfiniteCheck)
            {
                PlayerPrefs.SetInt("HighScoreInfinite", scoreCounter);
            }
        }
        else
        {
            if (scoreCounter > scoreCheck)
            {
                PlayerPrefs.SetInt("HighScore", scoreCounter);
            }
        }
    }

    public void AddScore(int valueToAdd)
    {
        scoreCounter = scoreCounter + valueToAdd;
    }

    public int GetScore()
    {
        return scoreCounter;
    }

    public void SetStars()
    {
        if (scoreCounter >= 3600)
        {
            threeStars = true;
        }
        else if (scoreCounter < 3600 && scoreCounter > 2600)
        {
            twoStars = true;
        }
        else if (scoreCounter <= 1600 && scoreCounter > 0)
        {
            oneStar = true;
        }
    }


}
