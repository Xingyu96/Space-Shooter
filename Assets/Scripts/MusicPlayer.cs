using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;

    private AudioSource music;

    void Awake()
    {
        if (instance != null && instance != this) { Destroy(gameObject); }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("music: loaded level" + level);
        
        if (level == 0)
        {
            music.Stop();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
        else if (level == 1 && music.clip != gameClip)
        {
            music.Stop();
            music.clip = gameClip;
            music.loop = true;
            music.Play();
        }

    }
}
