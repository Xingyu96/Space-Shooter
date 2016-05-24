using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

    private Text lose;
    private Text restart;
	// Use this for initialization
	void Start () {
        lose = transform.Find("LostMessage").GetComponent<Text>();
        restart = transform.Find("PlayAgain").GetComponent<Text>();
        lose.enabled = false;
        restart.enabled = false;
	}

    public void DisplayLose()
    {
        transform.Find("LostMessage").GetComponent<Text>().enabled = true;
        transform.Find("PlayAgain").GetComponent<Text>().enabled = true;
    }

}
