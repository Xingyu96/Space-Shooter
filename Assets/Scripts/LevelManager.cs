using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    public void loadLevel(string name){
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

    public void quitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayerDead()
    {
        loadLevel("Lose");
    }

}
