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

    private void Awake()
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
                cat.audioSource.Play();
            }
            //StartCoroutine(PlayMusic());
        }
    }
    /*
    public IEnumerator PlayMusic()
    {

    }
    */
}
