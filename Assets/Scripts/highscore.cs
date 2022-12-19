using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class highscore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI highScore;
    public int scorenum;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        score2.text = scorenum.ToString();
        score.text = scorenum.ToString();
    }

    public void GenerateNumber ()
    {
        int number = Random.Range(1, 11);
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }

    public void AddToScore(int point)
    {
        scorenum += point;
        score.text = scorenum.ToString();
        score2.text = scorenum.ToString();
        if (scorenum > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scorenum);
            highScore.text = scorenum.ToString();
        }
    }

  

}
