using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;

    Text scoreText;

    void Start()
    {
        scoreText = GameObject.FindObjectOfType<Text>();

    }
    public void Score(int point)
    {
        this.score += point;
        scoreText.text = ("SCORE: " + score);

    }

    public void Reset()
    {
        this.score = 0;
    }
}
