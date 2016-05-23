using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;

    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();

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
