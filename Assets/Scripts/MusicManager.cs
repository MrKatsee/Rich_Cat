using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    public static MusicManager Instance
    { get; private set; }

    public AudioSource audioSource;
    //public float musicDuration = 9.6f; //= 60f/100*16;
    public bool playMusic = false;

    public bool PlayMusic
    {
        get
        {
            return playMusic;
        }
        set
        {
            playMusic = value;

            if (playMusic == false)
            {
                GetComponent<AudioSource>().Stop();
            }
        }
    }

    float x = 0f;

    MusicManager() : base()
    {
        Instance = this;
    }
    private void Update()
    {
        //GameObject.Find("Text").GetComponent<Text>().text = playMusic.ToString() + " " + audioSource.isPlaying.ToString() + " " + MusicCat.cats.Count.ToString();

        if (playMusic == true && audioSource.isPlaying == false)
        {
            audioSource.Play();
            foreach (var cat in MusicCat.cats)
            {
                try
                {
                    cat.audioSource.time = 2.4f * x;
                    cat.audioSource.Play();

                }
                catch (MissingReferenceException) { }
            }

            x += 1f;
            if (x > 3f) x = 0f;
            //StartCoroutine(PlayMusic());
        }
    }
    /*
    public IEnumerator PlayMusic()
    {

    }
    */
}
