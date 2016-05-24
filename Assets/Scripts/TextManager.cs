using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
        transform.Find("LostMessage").GetComponent<Text>().enabled = false;
        transform.Find("PlayAgain").GetComponent<Text>().enabled = false;
        transform.Find("MainMenu").GetComponent<Text>().enabled = false;

	}

    public void DisplayLose()
    {
        transform.Find("LostMessage").GetComponent<Text>().enabled = true;
        transform.Find("PlayAgain").GetComponent<Text>().enabled = true;
        transform.Find("MainMenu").GetComponent<Text>().enabled = true;
    }

}
