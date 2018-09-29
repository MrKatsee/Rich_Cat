using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour {

    public static PlayManager instance;

    CameraZoom cameraZoom;

    private void Awake()
    {
        instance = this;

        cameraZoom = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
    }


    public int musicCatNum = 0;

    public int MusicCatNum
    {
        get
        {
            return musicCatNum;
        }

        set
        {
            musicCatNum = value;

            cameraZoom.musicCatNum_Camera = musicCatNum;
        }
    }

    public void SetMusicCatNum(int value)
    {
        if (value ==  1)
        {
            musicCatNum++;
        }
        else if (value == -1)
        {
            musicCatNum--;
        }
    }

}
