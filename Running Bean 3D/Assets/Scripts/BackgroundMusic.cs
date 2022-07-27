using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    bool isPaused = false;
    public AudioListener audioListener;
    public List<AudioSource> audioSources;
    public AudioSource aSource;

    private void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
     void OnMouseDown()
    {
        foreach (AudioSource audioSorce in audioSources)
        {
            AudioListener.pause = !AudioListener.pause;
        }
                    
    }
}