using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private static PlayMusic instance = null;

    public static PlayMusic Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();

        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<PlayMusic>().PlayMus();
        }
    }

    public void PlayMus()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMus()
    {
        if (audioSource.isPlaying) return;
        audioSource.Stop();
    }
}
